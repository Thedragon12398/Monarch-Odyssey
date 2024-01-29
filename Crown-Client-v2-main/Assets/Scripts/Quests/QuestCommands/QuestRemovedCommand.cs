using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRemovedCommand : QuestCommand
{
    private int questId;
    // Start is called before the first frame update
    public QuestRemovedCommand(int _questId)
    {
        questId = _questId;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the questmanager does not attempt to repeatidly process quest in update loot
        processing = true;

        GameManager.instance.player.RemoveQuest(questId);
        GameManager.instance.uiManager.CloseQuestDetails();
        GameManager.instance.uiManager.CloseQuestStepPanel();


        //otherwise remove the command
        GameManager.instance.questManager.RemoveQuestQueueCommand(this);


    }
}
