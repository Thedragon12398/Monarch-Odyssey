using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//from Tom Weiland's networking tutorial: https://www.youtube.com/playlist?list=PLXkn83W0QkfnqsK8I0RAz5AbUxfg3bOQ5
public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    private int xp;
    private int energyCarried;
    private string team;
    public List<QuestClass> currentQuests = new List<QuestClass>();

    public void setXP (int _xp)
    {
        xp = _xp;
        GameManager.instance.uiManager.setXP(_xp);
    }

    public int returnXP ()
    {
        return xp;
    }

    public void setEnergyCarried(int _energyCarried)
    {
        energyCarried = _energyCarried;
        GameManager.instance.uiManager.setEnergy(_energyCarried);
    }

    public int returnEnergyCarried()
    {
        return energyCarried;
    }

    public void setTeam(string _team)
    {
        team = _team;
        
    }

    public string returnTeamName()
    {
        return team;
    }

    public void AddQuest(QuestClass _quest)
    {
        currentQuests.Add(_quest);
        //string _position = _quest.questSteps[_quest.currentStep].lattitude + "," + _quest.questSteps[_quest.currentStep].longitude;
        AddWayPointMarker(_quest);

        //_quest.markerScript = GameManager.instance.mapManager.AddQuestWaypointMarker(_quest, _position);
        //Debug.Log("Quest Added" + _quest.questId);
    }

    public void AdvanceQuest(int _questId, int _nextStep)
    {
        QuestClass _quest = ReturnQuestbyID(_questId);
        _quest.currentStep = _nextStep;
        //Destroy the old quest waypoint marker
        DestroyQuestMarker(_quest);
        //Add the new quest waypoint marker
        AddWayPointMarker(_quest);
        
        //string _position = _quest.questSteps[_quest.currentStep].lattitude + "," + _quest.questSteps[_quest.currentStep].longitude;
        //_quest.markerScript = GameManager.instance.mapManager.AddQuestWaypointMarker(_quest, _position);
    }

    public void RemoveQuest(int _questId)
    {
        QuestClass _quest = ReturnQuestbyID(_questId);

        //destroy the waypoint marker
        DestroyQuestMarker(_quest);
        //remove quest from player's quest log
        currentQuests.Remove(_quest);
        Debug.Log("Quest Removed" + _questId + "quests in queue + " );
    }

    //check to see if player is already on the quest
    public bool OnQuest (int _questId)
    {
        foreach (QuestClass _quest in currentQuests)
        {
            if (_quest.questId == _questId)
            {
                return true;
            }
        }

        return false;
    }

    //return a quest from the player's quest log by it's ID
    private QuestClass ReturnQuestbyID(int _questId)
    {
        foreach (QuestClass _quest in currentQuests)
        {
            if (_quest.questId == _questId)
            {
                return _quest;
            }
        }

        return null;
    }

    private void DestroyQuestMarker(QuestClass _quest)
    {
        GameObject _marker = _quest.markerScript.gameObject;
        _quest.markerScript = null;
        Destroy(_marker);
    }

    private void AddWayPointMarker (QuestClass _quest)
    {
        //subtract one from the current step to get the index, as arrays begin at 0
        int _index = _quest.currentStep - 1;
        string _position = _quest.questSteps[_index].lattitude + "," + _quest.questSteps[_index].longitude;
        _quest.markerScript = GameManager.instance.mapManager.AddQuestWaypointMarker(_quest, _position);
        
    }

    

}
