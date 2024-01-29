using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTeamCommand : NetworkCommand
{
    public CreateTeamCommand(string _teamName, string _teamFocus, string _teamDescription, string _keywordOne, string _keywordTwo)
    {
        packet = new Packet((int)ClientPackets.createTeam);
        packet.Write(_teamName);
        packet.Write(_teamFocus);

        packet.Write(_teamDescription);
        packet.Write(_keywordOne);
        packet.Write(_keywordTwo);
        packetId = (int)ClientPackets.createTeam;
    }
}
