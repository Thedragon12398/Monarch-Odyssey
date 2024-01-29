using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLogin : MonoBehaviour
{
    //singleton that manages the various login options. Stores the appropriate network command based
    //on login option players choose and then returns it after client and server establish connection
    public static ManageLogin instance;
    private NetworkCommand loginCommand;
    
    private void Awake()
    //initialize the game manager singleton upon waking up
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance alreasy exists; destroying object!");
            Destroy(this);
        }
    }

    public void LoginwithUsername()
    //called when player press the "connect" button
    {
        loginCommand = new UserNameLoginCommand();

        ClientSend.AddQueueCommand(new ConnectCommand());       
        
    }

    public void LoginWithGoogle()
    {
        loginCommand = new GoogleLoginCommand();

        ClientSend.AddQueueCommand(new ConnectCommand());
               
    }

    public void Reconnect()
    {
        loginCommand = new ReconnectCommand();
        ClientSend.AddQueueCommand(new ConnectCommand());
    }

    public NetworkCommand ReturnLoginCommand()
    {
        return loginCommand;
    }
}
