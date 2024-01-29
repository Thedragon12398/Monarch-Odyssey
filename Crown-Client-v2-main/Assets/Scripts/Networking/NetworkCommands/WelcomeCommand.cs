using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeCommand : NetworkCommand
{
    //sent in response to welcome command from the server; used to link client with player in the database.
    //
    
    public WelcomeCommand()
    {
        packet = new Packet((int)ClientPackets.welcomeReceived);
        packet.Write(Client.instance.myId);
        packet.Write(Client.instance.connectionContext);
        packet.Write(Client.instance.username);
        packet.Write(Client.instance.password);
        packetId = (int)ClientPackets.welcomeReceived;

    }
    

}
