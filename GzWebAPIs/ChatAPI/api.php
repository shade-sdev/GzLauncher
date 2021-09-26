<?php


require_once($_SERVER['DOCUMENT_ROOT'] . "/includes/classes/ChatAPI.php");


$chatapi = new ChatAPI($con);
$paramCount = count($_GET);

switch ($paramCount) {

    case 0:
        if ($paramCount == 0) {
            $chatapi->fetchLastMessage();
        }

    case 1:
        if ($paramCount == 1) {
            $chatapi->fetchMessage($_GET['id']);
        }
        break;

    case 3:
        if ($paramCount == 3) {
            $chatapi->addMessage($_GET['userid'], $_GET['message'], $_GET['date']);
        }
        break;
}
