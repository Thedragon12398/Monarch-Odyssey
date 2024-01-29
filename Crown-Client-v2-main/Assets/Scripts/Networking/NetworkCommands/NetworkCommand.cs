using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCommand 
{
    protected Packet packet;
    protected int packetId; //the packet id of the packet; used to confirm receipt from server
        
    //if need be, can be overridden to send udp instead of tcp
    public virtual void Execute()
    {
        //packet.WriteLength();
        Client.instance.tcp.SendData(packet);
    }

    public virtual int ReturnPacketId()
    {
        return packetId;
    }

}
