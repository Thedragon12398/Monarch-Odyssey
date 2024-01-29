using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestAvaliableQuestsCommand : NetworkCommand
{
    // Sent to request a list of avaliable quests from the server
    public RequestAvaliableQuestsCommand()
    {
        packet = new Packet((int)ClientPackets.requestAvaliableQuests);
        packet.Write(Client.instance.username);
        packetId = (int)ClientPackets.requestAvaliableQuests;
    }
        

}
