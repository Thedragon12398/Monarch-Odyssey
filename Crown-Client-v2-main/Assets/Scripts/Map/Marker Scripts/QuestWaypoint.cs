using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWaypoint : MonoBehaviour
{
    //this script controls mouse click and collider behaviora on quest waypoint markers
    private QuestClass quest;

    public void Initialize(QuestClass _quest)
    {
        quest = _quest;
    }

    public void OnMouseDown()
    {
        //if overhead map is on and player clicks on waypoint, display active quest details window
        if (GameManager.instance.returnGameState() == 1)
        {
            GameManager.instance.uiManager.DisplayActiveQuestDetails(quest);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.uiManager.DisplayActionButton(quest);
                
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.uiManager.HideActionButton();
    }
}
