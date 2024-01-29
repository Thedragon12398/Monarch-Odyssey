using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAvaliableQuestCommand : QuestCommand
{
    // Start is called before the first frame update
    public AddAvaliableQuestCommand(QuestClass _quest)
    {
        quest = _quest;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the questmanager does not attempt to repeatidly process quest in update loot
        processing = true;
        //if player is not already on the quest, add it to the map
        if (!GameManager.instance.player.OnQuest(quest.questId))
        {

            //tell map manager to display quest waypoint on map
            string _position = quest.displayLat + "," + quest.displayLong;
            quest.markerScript = GameManager.instance.mapManager.AddQuestMarker(quest.questId, _position);
            GameManager.instance.questManager.avaliableQuests.Add(quest);

            
        }
        //otherwise remove the command
        GameManager.instance.questManager.RemoveQuestQueueCommand(this);


    }
}
