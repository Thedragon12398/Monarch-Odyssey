using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinLeaveTeamCommand : NetworkCommand
{
    //this queue command is sent when player asks to join, leave, or requests an invite to a team
    public JoinLeaveTeamCommand(string _teamName, string _joinLeave)
    {
        packet = new Packet((int)ClientPackets.joinLeaveTeam);
        packet.Write(_teamName);
        packet.Write(_joinLeave);       
        packetId = (int)ClientPackets.joinLeaveTeam;
    }
}
