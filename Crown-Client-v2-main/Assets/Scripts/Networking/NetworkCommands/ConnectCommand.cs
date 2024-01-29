using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectCommand : NetworkCommand
{
    //commands client to connect or reconnect to server.
    public ConnectCommand()
    {
        
    }


    public override void Execute()
    {
        packetId = 1;
        if (!Client.instance.isConnected)
        {
            Client.instance.ConnectToServer();
        }
    }
}
