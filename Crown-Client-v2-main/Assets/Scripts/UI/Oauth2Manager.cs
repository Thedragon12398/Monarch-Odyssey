using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public static class Oauth2Manager {
    //private const string clientSecret = "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";
    //private const string redirectURI = "https://monarchodysseygame.com/oauth2callback/";
    private const string localRedirectURI = "http://localhost/oauth2callback/";
    private const string serverRedirectURI = "https://monarchodysseygame.com/oauth2callback/";
    private const string scope = "scope=openid%20profile%20email";


    public static void GetAuthCode(string _monarchProjectClientID, string _clientStateToken)
    {

        string _escapedURI;
        if (Client.instance.useLocalIP)
        {
            _escapedURI = UnityWebRequest.EscapeURL(localRedirectURI);
        } else
        {
            _escapedURI = UnityWebRequest.EscapeURL(serverRedirectURI);
        }
        
        string oAuthURL = "https://accounts.google.com/o/oauth2/v2/auth?" + scope + "&"  //google oAuthUrl
            + "response_type=code"+ "&" //ask for a code to be returned
            + "state=" + _clientStateToken + "&"+ //identifying hash that server can use to identify which client initiated the request
            "redirect_uri=" + _escapedURI + "&" + //url to send request to
            "client_id=" + _monarchProjectClientID; //client ID of Monarch Odyssey project

        Debug.Log("oAUTH URL = " + oAuthURL);

        Application.OpenURL(oAuthURL);


    }
    
    
}
