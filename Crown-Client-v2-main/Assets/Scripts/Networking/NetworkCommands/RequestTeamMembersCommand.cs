using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestTeamMembersCommand : NetworkCommand
{
    // Start is called before the first frame update
    public RequestTeamMembersCommand(string _teamName)
    {
        packet = new Packet((int)ClientPackets.requestTeamMembers);
        packet.Write(_teamName);
        
        packetId = (int)ClientPackets.requestTeamMembers;
    }
}
