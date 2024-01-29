using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendStuffCommand : NetworkCommand
{
    // Start is called before the first frame update
    public SendStuffCommand()
    {
        packet = new Packet((int)ClientPackets.sendDaStuff);
        packet.Write(Client.instance.username);
        packetId = (int)ClientPackets.sendDaStuff;

    }
}
