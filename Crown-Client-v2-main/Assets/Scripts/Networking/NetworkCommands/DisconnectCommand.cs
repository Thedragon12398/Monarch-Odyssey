using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectCommand : NetworkCommand
{
    // Start is called before the first frame update
    public DisconnectCommand()
    {
        
    }


    public override void Execute()
    {
        if (Client.instance.isConnected)
        {
            Client.instance.Disconnect();
        }
    }
}
