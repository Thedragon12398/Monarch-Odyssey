using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogleLoginCommand : NetworkCommand
{
    public GoogleLoginCommand()
    {
        packet = new Packet((int)ClientPackets.loginWithGoogle);
        packetId = (int)ClientPackets.loginWithGoogle;

    }
}
