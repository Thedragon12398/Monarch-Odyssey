using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchTeamsCommand : NetworkCommand
{

    public SearchTeamsCommand(string _teamName, string _teamFocus, string _keywordOne, string _keywordTwo, string _keywordThree)
    {
        packet = new Packet((int)ClientPackets.searchTeams);
        packet.Write(_teamName);
        packet.Write(_teamFocus);

        
        packet.Write(_keywordOne);
        packet.Write(_keywordTwo);
        packet.Write(_keywordThree);
        packetId = (int)ClientPackets.searchTeams;
    }
}
