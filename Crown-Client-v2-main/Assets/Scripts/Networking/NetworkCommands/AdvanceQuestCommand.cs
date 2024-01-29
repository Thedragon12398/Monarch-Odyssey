using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceQuestCommand : NetworkCommand
{
    //sent when player completes one stage of a quest.
    public AdvanceQuestCommand(int _questId, int _completedQuestStep)
    {
        packet = new Packet((int)ClientPackets.advanceQuest);
        packet.Write(_questId);
        packet.Write(_completedQuestStep);
        packetId = (int)ClientPackets.advanceQuest;
    }
}
