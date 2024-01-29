using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkRequestTimer : MonoBehaviour
{
    public float secondsBeforeTimeout = 5;
    private float secondsRemaining = 0;
    private bool timerRunning = false;
    private bool sendSuceeded = true;
    private int retryCount = 0;
    private NetworkCommand sentCommand;
    // Start is called before the first frame update
    
    public void StartTimer(NetworkCommand _sentCommand)
    {
        
        Debug.Log("Timer started  " + sendSuceeded);
        sentCommand = _sentCommand;

        if (sentCommand is ConnectCommand)
        {
            Debug.Log("Connect command found, let client handle timeout");
            return;
        }

        secondsRemaining = secondsBeforeTimeout;
        timerRunning = true;
        //might not need this
        if (sendSuceeded)
        {
            retryCount = 3;
        } else
        {

        }

        
    }

    public void StopTimer(bool _sendSuceeded)
    {
        
        timerRunning = false;
        sendSuceeded = _sendSuceeded;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timerRunning)
        {
            if (secondsRemaining > 0)
            {
                secondsRemaining -= Time.deltaTime;
            } else
            {
                Debug.Log("Command Timed out!!! Do Stuff");

                StopTimer(false);
                if (sentCommand is ConnectCommand)
                {
                    //Debug.Log("Connect command timed out, let client handle that");
                    //return;

                }

                if (retryCount > 0)
                {
                    RetryCommand();
                } else
                {
                    
                    Debug.Log("Resending Command failed; trying to reconnect"); 
                    Client.instance.Disconnect();
                    ThreadManager.ExecuteOnMainThread(() => { ClientSend.Reconnect(); });
                }
                                
            }
        }
    }

    private void RetryCommand()
    {
        Debug.Log("Resending Command; Attempt " + retryCount);
        sentCommand.Execute();
        StartTimer(sentCommand);
        retryCount--;
    }
}
