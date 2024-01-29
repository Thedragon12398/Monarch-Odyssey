using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;

public class QuestManager : MonoBehaviour
{
    public List<QuestClass> avaliableQuests = new List<QuestClass>();
    public List<QuestCommand> questCommandQueue = new List<QuestCommand>();

    private void Update()
    {
        if (questCommandQueue.Count > 0)
        {
            QuestCommand _currentCommand = questCommandQueue[0];
            if (!_currentCommand.IsProcessing())
            {
                Debug.Log("PROCESSING QUEST COMMAND " + _currentCommand.GetType());
                _currentCommand.Process();
            }
        }
    }

    public void AddQuestQueueCommand(QuestCommand _questCommand)
    {
        Debug.Log("ADDING QUEST COMMAND " + _questCommand.GetType());
        questCommandQueue.Add(_questCommand);
    }

    public void RemoveQuestQueueCommand(QuestCommand _questCommand)
    {
        Debug.Log("Removing QUEST COMMAND " + _questCommand.GetType());
        questCommandQueue.Remove(_questCommand);
        
    }

    public void AddAvaliableQuest(QuestClass _quest)
    {
        //add quest to list of avaliable quests
        if (!GameManager.instance.player.OnQuest(_quest.questId))
        {
            
            //tell map manager to display quest waypoint on map
            string _position = _quest.displayLat + "," + _quest.displayLong;
            _quest.markerScript = GameManager.instance.mapManager.AddQuestMarker(_quest.questId, _position);
            avaliableQuests.Add(_quest);
        }         

    }

    //called when player accepts a quest; tells server that they want to take it
    public void AcceptQuest(int _questId)
    {
        QuestClass _quest = ReturnQuest(_questId);
        GameObject _marker = _quest.markerScript.gameObject;
        _quest.markerScript = null;
        Destroy(_marker);
        //reconnect to server before sending command. This is the handshake sequence.
        //ClientSend.AddQueueCommand(new ConnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //ClientSend.AddQueueCommand(new ReconnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //once reconnected, add the quest.
        ClientSend.AddQueueCommand(new AddQuestCommand(_questId)); 
    }

    //called when server adds quest to players database and server-side quest log
    public void QuestAdded(QuestClass _quest)
    {
        QuestClass _questToAdd = ReturnQuest(_quest.questId);
        //remove the quest from list of avaliable quests
        if (_questToAdd != null)
        {
            avaliableQuests.Remove(_questToAdd);
        }
        //add the quest to the player's quest log
        GameManager.instance.player.AddQuest(_quest);
        //close the quest details window
        GameManager.instance.uiManager.CloseQuestDetails();
        
    }

    //send message to server indicating that player has either completed a step of a quest or finished it
    public void QuestStepCompleted(QuestClass _quest)
    {
        //reconnect to server before sending command. This is the handshake sequence.
        //ClientSend.AddQueueCommand(new ConnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //ClientSend.AddQueueCommand(new ReconnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //remove quest if player has finished it
        if (_quest.currentStep >= _quest.totalQuestSteps)
        {
            ClientSend.AddQueueCommand(new QuestFinishedCommand(_quest.questId));            
        } else
        //otherwise advance quest to next step
        {
            ClientSend.AddQueueCommand(new AdvanceQuestCommand(_quest.questId, _quest.currentStep));            
        }

    }
    //when client recieves confirmation from server that advance quest command has been processed, advance quest
    //on the client.
    public void QuestAdvanced(int _questId, int _nextStep)
    {
        GameManager.instance.player.AdvanceQuest(_questId, _nextStep);
        GameManager.instance.uiManager.CloseQuestStepPanel();
    }

    //when client recieves confirmation from server that finish qyest command has been processed, remove quest
    //on the client.
    public void QuestFinished(int _questId)
    {
        GameManager.instance.player.RemoveQuest(_questId);
        GameManager.instance.uiManager.CloseQuestStepPanel();
    }

    //send command to server to remove quest
    public void RemoveQuest(int _questId)
    {
        //reconnect to server before sending command. This is the handshake sequence.
        //ClientSend.AddQueueCommand(new ConnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //ClientSend.AddQueueCommand(new ReconnectCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //remove quest 
        ClientSend.AddQueueCommand(new RemoveQuestCommand(_questId));

    }

    //when client recieves confirmation from server that remove quest command has been processed, remove quest
    //on the client.
    public void QuestRemoved(int _questId)
    {
        GameManager.instance.player.RemoveQuest(_questId);
        GameManager.instance.uiManager.CloseQuestDetails();
    }

    //utility to return quest by questID;
    public QuestClass ReturnQuest(int _questId)
    {
        Debug.Log("Quest ID = " + _questId);

        foreach (QuestClass _quest in avaliableQuests)
        {
            if (_quest.questId == _questId)
            {
                Debug.Log("quest found returning!!!");
                return _quest;
                
            }
        }

        //Debug.Log("quest NOT found returning null!!!");
        return null;
        
    }




}
