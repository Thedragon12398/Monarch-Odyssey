using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFinishedCommand : NetworkCommand
{
    //sent when a client finishes a quest
    public QuestFinishedCommand(int _questId)
    {
        packet = new Packet((int)ClientPackets.questFinished);
        packet.Write(_questId);
        packetId = (int)ClientPackets.questFinished;
    }
}
