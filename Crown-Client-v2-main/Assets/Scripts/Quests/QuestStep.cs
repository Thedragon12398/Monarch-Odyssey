using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStep
{
    //this class stores the properties for each step of the quest

    //the latitude of the step in the quest
    public string lattitude { get; set; }

    //the longitude of the step in the quest
    public string longitude { get; set; }

    //the action associated with step of the quest--tells the client what kind of button to display
    public string action { get; set; }

    //the id of the NPC associated with the quest
    public int npc { get; set; }

    //the text to be displayed in the client
    public string text { get; set; }
}
