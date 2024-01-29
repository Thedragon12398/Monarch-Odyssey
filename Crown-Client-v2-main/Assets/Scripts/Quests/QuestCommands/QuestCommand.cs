using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCommand 
{
    //base class for queue commands for adding quests and other content from the server
    protected QuestClass quest;
    protected bool processing = false;

    public bool IsProcessing()
    {
        return processing;
    }

    public virtual void Process ()
    {

    }
    
    
}
