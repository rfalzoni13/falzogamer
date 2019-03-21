<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class HomeController extends Controller
{
    public function index()
    {
        $token = "Bearer 0aApiuloUjxhmFXwX2wTYNHYgizRfbTLNCblelFy3-id7_0K4Ika3kBqiinO1NJ6WGrWkl9_aTgwJoiJZqn_JcbR0xd83Qe7xfT6GiA_NJXbs1MbNIp4MEAfFgqmmE-t405Q4oNuI2WR95lxaukLL9ewXKG0O-K9u-bVzxeH6-wzYYW6CYO0S6hFax4l-dVgT1WeIy5Jk2s9DalfvgPFg73n7jBs6YmbuUuApsc7XIgZ3-U2uZjxbczC5nRhwQPkuDpbS_SltaXSoSNQb80GmXan7oD2Mh2AZxlBIMtGzdTeU1_T2FtkifUQ1TKV5CtS";

        $curl = curl_init();

        curl_setopt_array($curl, array(
            CURLOPT_PORT => "50910",
            CURLOPT_URL => "http://localhost:50910/api/antiguera/admin/listartodososusuarios",
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_MAXREDIRS => 10,
            CURLOPT_TIMEOUT => 30,
            CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
            CURLOPT_CUSTOMREQUEST => "GET",
            CURLOPT_HTTPHEADER => array(
              "Authorization:".$token,
              "cache-control: no-cache"
            ),
          ));
          
          $response = curl_exec($curl);
          $err = curl_error($curl);
          
          curl_close($curl);
          
          if ($err) {
            echo "cURL Error #:" . $err;
          } else {
              $response = json_decode($response, true);
          }

        return View('home')->with(['response' => $response]);
    }
}
