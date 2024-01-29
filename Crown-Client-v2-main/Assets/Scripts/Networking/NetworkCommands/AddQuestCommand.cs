using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddQuestCommand : NetworkCommand
{ 
    //sends a request to the server to add a quest
    public AddQuestCommand(int _questId)
    {
        packet = new Packet((int)ClientPackets.addQuest);
        packet.Write(_questId);
        packetId = (int)ClientPackets.addQuest;
    }
}
