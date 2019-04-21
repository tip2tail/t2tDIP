<?php

require_once('config.inc.php');
$safePost = filter_input_array(INPUT_POST, [
    'AuthCode'  => FILTER_SANITIZE_STRING,
    'IPAddress' => FILTER_VALIDATE_IP,
]);

$outcome = new stdClass();
$outcome->Status = 'ERROR';
$outcome->Message = '';
$outcome->Code = 500;

do {

    if ($_SERVER['REQUEST_METHOD'] !== 'POST') {
        $outcome->Message = 'HTTP request was not of type POST';
        break;
    }

    if (!array_key_exists('AuthCode', $safePost)) {
        $outcome->Message = 'Auth code was missing from POST data';
        break;
    }
    if (!array_key_exists('IPAddress', $safePost)) {
        $outcome->Message = 'IP address was missing from POST data';
        break;
    }

    $authCode = trim($safePost['AuthCode']);
    $ipAddress = trim($safePost['IPAddress']);

    // Check the filtering again
    if ($authCode === '' && !validateAuthCode($authCode)) {
        $outcome->Message = 'Invalid auth code detected';
        break;
    }
    if (filter_var($ipAddress, FILTER_VALIDATE_IP) === false) {
        $outcome->Message = 'Invalid IP address detected';
        break;
    }

    // Security check
    if (strtolower($authCode) !== strtolower(REMOTE_AUTH_CODE)) {
        $outcome->Message = 'Auth code does not match - security failed';
        break;
    }

    // Load the existing IP address
    $currentIp = loadIp();

    // We are OK at this point - update the outcome
    $outcome->Code = 200;
    $outcome->Status = 'OK';
    $outcome->Message = 'No update was required';

    // Change if required
    if ($currentIp !== $ipAddress) {
        saveIp($ipAddress);
        $outcome->Message = 'IP address was updated to: ' . $ipAddress;
        $outcome->Status = 'UPDATED';
    }

} while (false);

// Set the required code and return as JSON
http_response_code(($outcome->Code));
print(json_encode($outcome));

exit(0);
