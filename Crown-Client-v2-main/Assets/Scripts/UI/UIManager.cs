using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//from Tom Weiland's networking tutorial: https://www.youtube.com/playlist?list=PLXkn83W0QkfnqsK8I0RAz5AbUxfg3bOQ5

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject startPanel;
    public LoginManager loginPanel;
        

    private void Awake()
    //initialize the UIManager singleton upon waking up
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists; destroying object!");
            Destroy(this);
        }
    }


    private void Start()
    {
        loginPanel.ToggleLoginPanel(false);
        //loginPanel.gameObject.SetActive(false);
        startPanel.SetActive(true);
        
    }

    public void ShowLoginPanel()
    {
        loginPanel.ToggleLoginPanel(true);
        loginPanel.ToggleGoogleLoginButton();
        startPanel.SetActive(false);

        
      
    }

    
    public void LaunchRegistrationScene()
    {
        //set client connection context to 1, so that server knows client wants to register. TODO: Probably this should be its own command.
        Client.instance.connectionContext = 1;
        SceneLoader.Load(SceneNames.RegistrationScene);
    }
    

    
}
