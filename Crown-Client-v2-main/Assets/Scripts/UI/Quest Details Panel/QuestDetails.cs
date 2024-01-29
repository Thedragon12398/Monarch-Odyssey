using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDetails : MonoBehaviour
{
    public Text titleText;
    //these panels are displayed if the quest is avaliable
    public QuestDescriptionController avaliableDetailsPanel;
    public GameObject avaliableButtonsPanel;
    //these panels are displayed if the quest is active
    public QuestDescriptionController activeDetailsPanel;
    public GameObject activeButtonsPanel;
    
    private QuestClass quest;
    
    // Initialize is called
    public void PopulateAvaliableQuestDetails(QuestClass _quest)
    {
        quest = _quest;
        titleText.text = _quest.questName;
        TogglePanelComponents(true);        
        avaliableDetailsPanel.SetDescription(_quest.questDescription);
        
        quest = _quest;

    }

    public void PopulateActiveQuestDetails(QuestClass _quest)
    {
        TogglePanelComponents(false);
        activeDetailsPanel.SetDescription(_quest.questDescription);
        activeDetailsPanel.SetObjectives(_quest);
        quest = _quest;
        titleText.text = _quest.questName;
    }

    public void QuestAccepted()
    {
        GameManager.instance.questManager.AcceptQuest(quest.questId);
    }

    public void RemoveQuest()
    {
        GameManager.instance.questManager.RemoveQuest(quest.questId);
    }

    private void TogglePanelComponents(bool _toggle)
    {
        //if _toggle = true, show the avaliable quest components
        //if _toggle = false, show the active quest components
        avaliableDetailsPanel.gameObject.SetActive(_toggle);
        avaliableButtonsPanel.SetActive(_toggle);
        activeDetailsPanel.gameObject.SetActive(!_toggle);
        activeButtonsPanel.SetActive(!_toggle);

    }
}
