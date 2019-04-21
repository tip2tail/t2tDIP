<?php

// Insert your Auth Code from the Windows application here...
define('REMOTE_AUTH_CODE', '');

// ========================= DO NOT EDIT BELOW HERE ============================ //

// Protect against people reading this file!
if (basename(__FILE__) == basename($_SERVER["SCRIPT_FILENAME"])){
    // This is bad!  This file should never be called directly - redirect to to the index.php file
    header("Location: index.php\r\n");
}

function loadIp() {
    if (!file_exists('ip.txt')) {
        saveIp('');
    }
    return file_get_contents('ip.txt');
}

function saveIp($ip) {
    @unlink('ip.txt');
    file_put_contents('ip.txt', $ip);
}

function validateAuthCode($code) {
    // $guid = 'A98C5A1E-A742-4808-96FA-6F409E799937';
    $guid = strtoupper($code);
    if (preg_match('/^\{?[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}\}?$/', $guid)) {
        return true;
    }
    return false;
}

function redirectToIp() {
    $ip = loadIp();
    if (filter_var($ip, FILTER_VALIDATE_IP) === false) {
        http_response_code(500);
        echo "ERROR - No redirection IP found";
    } else {
        header("Location: $ip\r\n");
    }
}
