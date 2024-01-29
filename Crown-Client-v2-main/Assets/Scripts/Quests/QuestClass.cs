using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to hold quest details when retrieved from the database

public class QuestClass
{
    //the id of the quest; each quest has a unique id in the database
    public int questId { get; set; }

    //the name of the quest; as it should be displayed in the client
    public string questName { get; set; }

    //the description of the quest; as it should be displayed in the client
    public string questDescription { get; set; }

    //the type of the quest
    public int questType { get; set; }

    //how long players have to complete the quest
    public int questDuration { get; set; }

    //which classes of players the quest is intended for
    public int questSpecialization { get; set; }

    //whether or not the quest can be repeated; stored as either a 0 or a 1 in the database
    public bool isQuestRepeatiable { get; set; }

    //xp players receive for completing the quest 
    public int xpAwarded { get; set; }
    public int energyAwarded { get; set; }

    //the initial lattitude where the quest marker should appear. If set to zero, client displays it as window or on call board first
    public string displayLat { get; set; }

    //the initial longitude where the quest marker should appear. If set to zero, client displays it as window or on call board first
    public string displayLong { get; set; }

    //how many total steps the quest contains (5 steps maximum at the moment)
    public int totalQuestSteps { get; set; }
    //current step player is on (5 steps maximum at the moment)
    public int currentStep { get; set; }

    //list to hold the distinct steps of each quest
    public List<QuestStep> questSteps = new List<QuestStep>();

    public PositionMarker markerScript;


}
