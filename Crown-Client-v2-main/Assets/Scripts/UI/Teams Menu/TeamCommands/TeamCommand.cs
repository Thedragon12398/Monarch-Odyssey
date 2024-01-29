using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCommand 
{
    protected bool processing = false;

    public bool IsProcessing()
    {
        return processing;
    }

    public virtual void Process()
    {

    }
}
