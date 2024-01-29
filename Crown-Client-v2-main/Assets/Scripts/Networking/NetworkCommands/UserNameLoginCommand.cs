using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserNameLoginCommand : NetworkCommand
{
    //used to login with username and password; might be disabled once google login is working
    public UserNameLoginCommand()
    {
        packet = new Packet((int)ClientPackets.userNameLogin);
        packet.Write(Client.instance.connectionContext);
        packet.Write(Client.instance.username);
        packet.Write(Client.instance.password);
        packetId = (int)ClientPackets.userNameLogin;

    }
}
