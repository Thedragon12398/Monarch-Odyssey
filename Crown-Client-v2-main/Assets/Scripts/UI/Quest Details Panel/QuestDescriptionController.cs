using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDescriptionController : MonoBehaviour
{
    // this script is attached to the desciption panels in the quest UI; controls the text that is displayed
    //and maybe other elements

    public Text descriptionText;
    public Text currentObjectiveText;
    public void SetDescription(string _questDescription)
    {
        descriptionText.text = _questDescription;
    }

    public void SetObjectives(QuestClass _quest)
    {
        int _index = _quest.currentStep - 1;
        currentObjectiveText.text = _quest.questSteps[_index].text;
    }
}
