<?php


require_once($_SERVER['DOCUMENT_ROOT'] . "/BoxAPI/includes/classes/BoxAPI.php");


$boxapi = new BoxAPI($con);
$paramCount = count($_GET);
switch ($paramCount) {

    case 0:
        if ($paramCount == 0) {
            $boxapi->refreshToken();
        }

    case 1:
        if ($paramCount == 1) {
            if (isset($_GET['search'])) {
                $boxapi->searchFile($_GET['search']);
            } else
            if (isset($_GET['share'])) {
                $boxapi->getShareLink($_GET['share']);
            }
        }
        break;

    case 3:
        if ($paramCount == 3) {
            if (isset($_GET['list'])) {
                $boxapi->listFiles($_GET['offset'], $_GET['limit']);
            }
        }
        break;
}
