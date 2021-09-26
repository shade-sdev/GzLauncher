<?php
require_once($_SERVER['DOCUMENT_ROOT'] . "/BoxAPI/includes/classes/DB.php");
class BoxAPI
{


    private $con;

    public function __construct($con)
    {

        $this->con = $con;
    }


    public function getTokens()
    {
        $db = new DB($this->con);
        $params = array('id' => 1);
        $query = $db->apiFetch("boxapi", $params);
        $row = $query->fetch(PDO::FETCH_ASSOC);
        $tokens = array($row["accesstoken"], $row["refreshtoken"]);

        return $tokens;
    }


    public function refreshToken()
    {

        $tokens = $this->getTokens();
        $ch = curl_init();

        curl_setopt($ch, CURLOPT_URL, 'https://api.box.com/oauth2/token');
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_POST, 1);
        curl_setopt($ch, CURLOPT_POSTFIELDS, "client_id=&client_secret=&refresh_token=$tokens[1]&grant_type=refresh_token");

        $headers = array();
        $headers[] = 'Content-Type: application/x-www-form-urlencoded';
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

        $result = curl_exec($ch);
        $decoded = json_decode($result, true);


        $params = array('accesstoken' => $decoded["access_token"], 'refreshtoken' => $decoded["refresh_token"]);
        $additionalparams = array('id' => 1);
        $db = new DB($this->con);
        $db->updateData("boxapi", $params, $additionalparams);


        header("Content-Type: JSON");
        echo json_encode($decoded, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT);


        if (curl_errno($ch)) {
            echo 'Error:' . curl_error($ch);
        }
        curl_close($ch);
    }

    public function listFiles($offset, $limit)
    {

        $tokens = $this->getTokens();


        $ch = curl_init();

        curl_setopt($ch, CURLOPT_URL, 'https://api.box.com/2.0/folders/0/items?offset=' . $offset . '&limit=' . $limit . '&sort=date&direction=DESC');
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'GET');


        $headers = array();
        $headers[] = 'Authorization: Bearer ' . $tokens[0];
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

        $result = curl_exec($ch);

        $decoded = json_decode($result, true);

        header("Content-Type: JSON");
        echo json_encode($decoded, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT);
        if (curl_errno($ch)) {
            echo 'Error:' . curl_error($ch);
        }
        curl_close($ch);
    }


    public function getShareLink($id)
    {
        $tokens = $this->getTokens();
        $ch = curl_init();

        curl_setopt($ch, CURLOPT_URL, 'https://api.box.com/2.0/files/' . $id . '?fields=shared_link');
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'PUT');

        curl_setopt($ch, CURLOPT_POSTFIELDS, "{\n       \"shared_link\": {\n         \"access\": \"open\",\n         \"permissions\": {\n           \"can_download\": true\n         }\n       }\n     }");

        $headers = array();
        $headers[] = 'Authorization: Bearer ' . $tokens[0];
        $headers[] = 'Content-Type: application/x-www-form-urlencoded';
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

        $result = curl_exec($ch);

        $decoded = json_decode($result, true);

        header("Content-Type: JSON");
        echo json_encode($decoded, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT);

        if (curl_errno($ch)) {
            echo 'Error:' . curl_error($ch);
        }
        curl_close($ch);
    }

    public function searchFile($search)
    {
        $tokens = $this->getTokens();
        $ch = curl_init();

        curl_setopt($ch, CURLOPT_URL, 'https://api.box.com/2.0/search?query=' . $search);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
        curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'GET');


        $headers = array();
        $headers[] = 'Authorization: Bearer ' . $tokens[0];
        curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);

        $result = curl_exec($ch);

        $decoded = json_decode($result, true);

        header("Content-Type: JSON");
        echo json_encode($decoded, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT);
        if (curl_errno($ch)) {
            echo 'Error:' . curl_error($ch);
        }
        curl_close($ch);
    }
}
