<?php
require_once($_SERVER['DOCUMENT_ROOT'] . "/BoxAPI/includes/classes/DB.php");
class ChatAPI
{

    private $start = 0;
    private $response = array();
    private $con;

    public function __construct($con)
    {

        $this->con = $con;
    }

    public function echoData($query)
    {

        while ($row = $query->fetch(PDO::FETCH_ASSOC)) {
            $this->response[$this->start]['id'] = $row['id'];
            $this->response[$this->start]['userid'] = $row['userid'];
            $this->response[$this->start]['message'] = $row['message'];
            $this->response[$this->start]['date'] = $row['date'];
            $this->start++;
        }
        header("Content-Type: JSON");
        echo json_encode($this->response, JSON_PRETTY_PRINT);



        $this->start = 0;
        $this->response = array();
    }

    public function fetchMessage($id)
    {
        $db = new DB($this->con);
        $params = array('id' => $id);
        $query =  $db->apiFetch("messages", $params);
        $this->echoData($query);
    }

    public function fetchLastMessage()
    {
        $db = new DB($this->con);

        $query =  $db->apiFetchLastMessage("SELECT * FROM messages ORDER by id DESC LIMIT 1");
        $this->echoData($query);
    }


    public function addMessage($userid, $message, $date)
    {
        $db = new DB($this->con);
        $params = array('userid' => $userid, 'message' => $message, 'date' => $date);
        $db->addData("messages", $params);
        header("Content-Type: JSON");
        echo json_encode(['response' => 'true'], JSON_PRETTY_PRINT);
    }
}
