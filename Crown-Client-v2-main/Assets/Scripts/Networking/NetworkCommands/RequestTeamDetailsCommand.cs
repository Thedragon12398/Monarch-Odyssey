using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTeamDetailsCommand : NetworkCommand
{
    
    public RequestTeamDetailsCommand(string _teamName)
    {
        packet = new Packet((int)ClientPackets.requestTeamDetails);
        packet.Write(_teamName);
        packetId = (int)ClientPackets.requestTeamDetails;
    }
}
