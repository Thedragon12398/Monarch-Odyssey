using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestAdvancedCommand : QuestCommand
{
    // Start is called before the first frame update
    private int questId;
    private int nextStep;

    public QuestAdvancedCommand(int _questID, int _nextStep)
    {
        questId = _questID;
        nextStep = _nextStep;
        processing = false;
    }

    public override void Process()
    {
        //set processing to true so that the questmanager does not attempt to repeatidly process quest in update loot
        processing = true;

        GameManager.instance.player.AdvanceQuest(questId, nextStep);
        GameManager.instance.uiManager.CloseQuestStepPanel();

        //otherwise remove the command
        GameManager.instance.questManager.RemoveQuestQueueCommand(this);


    }
}
