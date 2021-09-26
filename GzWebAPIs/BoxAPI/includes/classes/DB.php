<?php
require_once($_SERVER['DOCUMENT_ROOT'] . "/BoxAPI/includes/config.php");
class DB
{
    private $con;


    public function __construct($con)
    {

        $this->con = $con;
    }


    public function apiFetch($table, $params)
    {

        $data = "";
        foreach ($params as $field => $value) {

            $data .= "`$field` = :$field AND ";
        }
        $data = rtrim($data, "AND ");

        $query = $this->con->prepare("SELECT * FROM $table WHERE $data");

        foreach ($params as $field => $value) {

            $query->bindValue(':' . $field, $value, PDO::PARAM_STR);
        };

        $query->execute();

        return $query;
    }

    public function apiFetchLastMessage($sql)
    {
        $query = $this->con->prepare($sql);

        $query->execute();
        return $query;
    }

    public function addData($table, $params)
    {


        $dataFields = "";
        $data = "";

        foreach ($params as $field => $value) {

            $dataFields .= "`$field`,";
        }

        $dataFields = rtrim($dataFields, ", ");



        foreach ($params as $field => $value) {

            $data .= ":$field,";
        }

        $data = rtrim($data, ", ");

        $query = $this->con->prepare("INSERT INTO `$table` ($dataFields) VALUES ($data)");


        foreach ($params as $field => $value) {

            $query->bindValue(':' . $field, $value, PDO::PARAM_STR);
        };

        $response = $query->execute();
        return $response;
    }

    public function updateData($table, $params, $additionalparams)
    {
        $updateSQL = "";
        $id = "";

        foreach ($params as $field => $value) {

            $updateSQL .= "`$field` = :$field,";
        }

        foreach ($additionalparams as $field => $value) {

            $id .= "`$field` = :$field";
        }

        $updateSQL = rtrim($updateSQL, ", ");

        $query = $this->con->prepare("UPDATE `$table` SET $updateSQL WHERE $id");

        foreach ($params as $field => $value) {

            $query->bindValue(':' . $field, $value, PDO::PARAM_STR);
        };

        foreach ($additionalparams as $field => $value) {

            $query->bindValue(':' . $field, $value, PDO::PARAM_INT);
        };

        $response = $query->execute();
        echo json_encode(['response' => $response]);
    }
}
