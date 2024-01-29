using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconnectCommand : NetworkCommand
{
    //sent in response to welcome command from the server; used to reconnect client with player in the database.   
    public ReconnectCommand()
    {
        packet = new Packet((int)ClientPackets.reconnect);
        packet.Write(SceneLoader.returnCurrentScene());
        packet.Write(Client.instance.username);
        packet.Write(Client.instance.password);
        packetId = (int)ClientPackets.reconnect;

    }
}
