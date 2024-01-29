using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField userNameField;
    public InputField passwordField;
    public Button googleLoginButton;
    

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    public void ToggleLoginPanel(bool _toggle)
    //displays or hides the Login Panel; sets its components to inactive or active
    {
        userNameField.interactable = _toggle;
        passwordField.interactable = _toggle;
        gameObject.SetActive(_toggle);
    }

    public void ResetInputFields ()
    //resets the texts on both input fields
    {
        userNameField.text = "";
        passwordField.text = "";
    }
    
    public void ToggleGoogleLoginButton()
    {
        if (Client.instance.useLocalIP)
        {
            //maybe not needed since looks like I can text the google oauth from local machine!
            googleLoginButton.gameObject.SetActive(true);
        }
    }
    

    public void LoginToServer()
    //called when player press the "connect" button
    {
        //set username and password on the client
        Client.instance.username = userNameField.text;
        Client.instance.password = passwordField.text;
        Client.instance.connectionContext = 0;
        //then pass login request to the Login Manager Singleton
        ManageLogin.instance.LoginwithUsername();
        
        

    }

    public void LoginWithGoogle()
    {
        //pass login request to the Login Manager Singleton
        ManageLogin.instance.LoginWithGoogle();
        
    }
}
