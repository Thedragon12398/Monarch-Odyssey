using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestStepPanel : MonoBehaviour
{
    public Text titleText;
    public Text stepDescription;
    public Text buttonText;

    private QuestClass quest;

    public void Initialize(QuestClass _quest)
    {
        quest = _quest;
        titleText.text = quest.questName;
        //substract 1 from the current quest step, since lists and arrays begin at 0
        int _currentStep = quest.currentStep -1;
        stepDescription.text = quest.questSteps[_currentStep].text;
        buttonText.text = quest.questSteps[_currentStep].action;
    }
}
