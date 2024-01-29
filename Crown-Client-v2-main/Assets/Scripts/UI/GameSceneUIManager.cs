using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUIManager : MonoBehaviour
{
    public BuildingInfoPanel buildingInfoPanel;
    public QuestDetails questDetailsPanel;
    public QuestListPanel questListPanel;
    public QuestStepPanel questStepPanel;
    public Button actionButton;
    public Text ping;
    public Text xpLabel;
    public Text energyLabel;
    private int pingCount = 0;
    private QuestClass actionButtonQuest; //quest that is associated with the action button
                                          //this is set when the action button appears / is triggered

    private void Start()
    {
        //configure the initial UI
        questDetailsPanel.gameObject.SetActive(false);
        questListPanel.gameObject.SetActive(false);
        actionButton.gameObject.SetActive(false);
        questStepPanel.gameObject.SetActive(false);
        buildingInfoPanel.gameObject.SetActive(false);
        ping.color = Color.yellow;
    }

    public void setXP(int _xp)
    {
        xpLabel.text = _xp.ToString();
    }

    public void setEnergy(int _energyCarried)
    {
        energyLabel.text = _energyCarried.ToString();
    }
    
    public void QuestButtonClicked()
    {
        questListPanel.PopulateQuestList();
        questListPanel.gameObject.SetActive(true);
    }

    public void MapButtonClicked()
    {
        if (!GameManager.instance.mapCamera.isActiveAndEnabled)
        {
            GameManager.instance.DisplayOverHeadMap();
        }
        else
        {
            GameManager.instance.CloseOverHeadMap();
        }
    }

    public void DisplayQuestDetails(int _questID)
    {
        QuestClass _quest = GameManager.instance.questManager.ReturnQuest(_questID);
        questDetailsPanel.PopulateAvaliableQuestDetails(_quest);
        questDetailsPanel.gameObject.SetActive(true);
    }

    public void DisplayActiveQuestDetails(QuestClass _quest) 
    {
        questDetailsPanel.PopulateActiveQuestDetails(_quest);
        questDetailsPanel.gameObject.SetActive(true);
    }

    public void CloseQuestDetails()
    {
        questDetailsPanel.gameObject.SetActive(false);
    }

    public void CloseQuestList()
    {
        questListPanel.gameObject.SetActive(false);
        questListPanel.RemoveButtons();

    }

    public void CloseQuestStepPanel()
    {
        questStepPanel.gameObject.SetActive(false);
    }

    public void CloseBuildingInfoPanel()
    {
        buildingInfoPanel.gameObject.SetActive(false);
    }

    //called when player triggers quest waypoint collider
    //might need to make multiple methods based on different objects
    public void DisplayActionButton(QuestClass _quest)
    {
        if (questStepPanel.gameObject.activeSelf)
        {
            return;
        }

        actionButtonQuest = _quest;
        actionButton.enabled = true;
        actionButton.gameObject.SetActive(true);
    }

    public void HideActionButton()
    {
        actionButton.enabled = false;
        actionButton.gameObject.SetActive(false);
    }

    public void ActionButtonClicked()
    {
        questStepPanel.Initialize(actionButtonQuest);
        questStepPanel.gameObject.SetActive(true);
        HideActionButton();
    }

    public void QuestStepButtonCLicked()
    {
        Debug.Log("ADvance Quest Button Clicked!");
        GameManager.instance.questManager.QuestStepCompleted(actionButtonQuest);
    }

    public void PingReceived ()
    {
        pingCount++;
        ping.text = "Ping " + pingCount;

        if (ping.color == Color.yellow)
        {
            ping.color = Color.red;
        } else
        {
            ping.color = Color.yellow;
        }

    }



}
