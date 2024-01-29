using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//send to request a list of active quests in the player's quest log from the server;
public class RequestActiveQuestsCommand : NetworkCommand {
    // Start is called before the first frame update
    public RequestActiveQuestsCommand()
    {
        packet = new Packet((int) ClientPackets.requestActiveQuests);
        packet.Write(Client.instance.username);
        packetId = (int)ClientPackets.requestActiveQuests;
    }
    
}
