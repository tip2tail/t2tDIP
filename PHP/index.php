<?php

require_once('config.inc.php');

$port = "80";
if (array_key_exists('port', $_GET)) {
    $port = $_GET['port'];
}

redirectToIp($port);
