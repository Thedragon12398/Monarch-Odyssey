using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddActiveQuestCommand : QuestCommand
{
    public AddActiveQuestCommand(QuestClass _quest)
    {
        quest = _quest;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the questmanager does not attempt to repeatidly process quest in update loot
        processing = true;
        
        QuestClass _questToAdd = GameManager.instance.questManager.ReturnQuest(quest.questId);
        //remove the quest from list of avaliable quests
        if (_questToAdd != null)
        {
            GameManager.instance.questManager.avaliableQuests.Remove(_questToAdd);
        }
        //add the quest to the player's quest log
        GameManager.instance.player.AddQuest(quest);
        //close the quest details window
        GameManager.instance.uiManager.CloseQuestDetails();

        //otherwise remove the command
        GameManager.instance.questManager.RemoveQuestQueueCommand(this);


    }
}
