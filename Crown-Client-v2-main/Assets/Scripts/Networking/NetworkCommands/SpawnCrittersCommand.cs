using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrittersCommand : NetworkCommand
{
    // called to spawn critters once all of the player data and quests have been pulled down from the server.
    public SpawnCrittersCommand()
    {
        
    }

    public override void Execute()
    {
        //CritterFactory.instance.SpawnCritters();
    }
}
