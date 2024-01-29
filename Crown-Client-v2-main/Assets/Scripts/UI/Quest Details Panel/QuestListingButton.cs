using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestListingButton : MonoBehaviour
{

    public Text buttonLabelText;
    private QuestClass quest;
    
    public void Initialize(QuestClass _quest)
    {
        quest = _quest;
        buttonLabelText.text = quest.questName;
    }

    public void QuestListingClicked()
    {
        GameManager.instance.uiManager.CloseQuestList();
        GameManager.instance.uiManager.DisplayActiveQuestDetails(quest);
    }
}
