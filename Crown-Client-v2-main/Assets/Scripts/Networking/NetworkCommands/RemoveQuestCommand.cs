using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveQuestCommand : NetworkCommand
{
    public RemoveQuestCommand(int _questId)
    {
        packet = new Packet((int)ClientPackets.removeQuest);
        packet.Write(_questId);
        packetId = (int)ClientPackets.removeQuest;
    }
}
