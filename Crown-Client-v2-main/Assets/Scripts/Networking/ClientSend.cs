using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//from Tom Weiland's networking tutorial: https://www.youtube.com/playlist?list=PLXkn83W0QkfnqsK8I0RAz5AbUxfg3bOQ5

public class ClientSend : MonoBehaviour
{
    private static List<NetworkCommand> queuedCommands = new List<NetworkCommand>();
    private static List<NetworkCommand> cachedQueueCommands = new List<NetworkCommand>();
    private static ClientSend instance;
    private static bool processingCommand = false;
    private static NetworkCommand currentCommand;
    public NetworkRequestTimer timer;

    private void Awake()
    {
        instance = this;
    }

    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    //when client wants to contact the server, it adds a network command to the queue with this method.
    public static void AddQueueCommand(NetworkCommand _command)
    {
        
        Debug.Log("Adding queue command " + _command.GetType() + " queue length " + queuedCommands.Count + " processing " + processingCommand);

        if (_command is BlockingCommand)
        {
            Debug.Log("Blocking Command Found!");
            return;
        }

        
        //add the network command to the queue
        queuedCommands.Add(_command);

        //if reconnect is called, add any delayed, failed, or deferred commands back into the queue after the reconnect command
        if (_command is ReconnectCommand)
        {
            Debug.Log("Reconnect Command Found! " + " " + queuedCommands.Count);
            foreach (NetworkCommand _cachedCommand in cachedQueueCommands)
            {
                
                queuedCommands.Add(_cachedCommand);
            }
            int count = 0;

            foreach (NetworkCommand _c in queuedCommands)
            {
                Debug.Log("COMMAND IN QUEUE = " + _c.GetType() + " position = " + count);
                count++;
            } 
            
            cachedQueueCommands.Clear();
            Debug.Log("Reconnect Command Found! " + " " + queuedCommands.Count);
        }
        //check the queue to see if any commands are waiting to be processed.
        ProcessQueueCommands();
    }

    //called by NetworkRequestTimer when a network request has timed out
    public static void Reconnect()
    {
        //Debug.Log("RECONNECT CALLED! " + queuedCommands[0].GetType() + " " + processingCommand);
        //cache existing queued commands and clear the queue and current command
        cachedQueueCommands.AddRange(queuedCommands);
        ClearCommandQueue();
        currentCommand = null;
        //configure login manager to handle reconnect       
        //tell login manager to add connect command to the queue. 
        ManageLogin.instance.Reconnect();
               
             
        

    }

    public static void AddQueueCommand(int _position, NetworkCommand _command)
    {
        queuedCommands.Insert(0,_command);
         processingCommand = false;
        
        ProcessQueueCommands();
    }

    public static void ClearCommandQueue ()
    {
        Debug.Log("Clear command queue called");
        queuedCommands.Clear();
        processingCommand = false;

    }

    
    //this method checks the queue for unprocessed commands. It is called whenever the client adds a command to the queue or whenever the client received a response from the server.
    private static void ProcessQueueCommands()
    {
        //Debug.Log("Checking queue for unprocessed commands. Queue Length = " + queuedCommands.Count);

        //if there is a network command waiting and if the client is not already processing a command (waiting for a response from the server), then execute the command.
        //otherwise do nothing
        if (queuedCommands.Count > 0 && !processingCommand)
        {
            currentCommand = queuedCommands[0];
            currentCommand.Execute();
            //Debug.Log("------------->SENDING " + currentCommand.GetType() + " " + currentCommand.ReturnPacketId());
            //start the timeout timer.
            instance.timer.StartTimer(currentCommand);
            processingCommand = true;
        }

       
    }

    
    //called when the server responds.
    public static void ResetRequestTimer(int _packetId)
    {
        if (_packetId != currentCommand.ReturnPacketId())
        {
            Debug.Log("ERROR: PACKET MATCH NOT FOUND " + currentCommand.ReturnPacketId() + " " + _packetId);
            //probably need to disconnect client here 
        }
       
        //stop the timeout timer
        instance.timer.StopTimer(true);
        //if the network queue is not empty then remove the command that has just been executed from the queue 
        if (queuedCommands.Count != 0)
        {
            queuedCommands.Remove(currentCommand);
            currentCommand = null;
        }

        //otherwise just set the processing command flag to false
        processingCommand = false;
        //check queue one more time to be sure nothing else needs to be done.
        ProcessQueueCommands();
    }

    private void Update()
    {
        //ExecuteQueuedCommands();
    }

    public static void ExecuteQueuedCommands()
    {
        if (queuedCommands.Count > 0)
        {
            
            //if command in queue is blocking command, skip until it is unlocked
            NetworkCommand _command = queuedCommands[0];
            if (_command is BlockingCommand)
            {
                //Debug.Log("Blocking command found! Commands waiting = " + queuedCommands.Count);
                foreach (NetworkCommand _com in queuedCommands)
                return;
            }
            //otherwise execute the first command in the queue
            _command.Execute();
            //instance.StartCoroutine(instance.StartRequestTimer());
            
            //remove the command once it has been executes
            queuedCommands.Remove(_command);
           
        }        
    }


    public static void UnlockQueueCommand()
    {
        if (queuedCommands.Count > 0)
        {
            //iterate through the commands and remove ONLY the first blocking command that is found
            foreach (NetworkCommand _command in queuedCommands)
            {
                if (_command is BlockingCommand)
                {
                    //Debug.Log("Unlocking Command. " + _command.GetType().ToString() + " Commands waiting = " + queuedCommands.Count);
                    queuedCommands.Remove(_command);
                    return;
                }
            }
        }
    }

   


    #region Packets
    /*
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(SceneLoader.returnCurrentScene());
            _packet.Write(Client.instance.username);
            _packet.Write(Client.instance.password);
            SendTCPData(_packet);

        }
    }
    
    public static void KeepAlive()
    {
        using (Packet _packet = new Packet((int)ClientPackets.keepAlive))
        {
            _packet.Write(Client.instance.username);
            SendTCPData(_packet);

        }
    }
    

    public static void SendDaStuff()
    {
        using (Packet _packet = new Packet((int)ClientPackets.sendDaStuff))
        {
            _packet.Write(Client.instance.username);
            SendTCPData(_packet);

        }
    }

    */
    public static void PlayerMovement(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

    public static void UpdateProfileDetails(string _firstName, string _lastName, string _tagline)
    {
        using (Packet _packet = new Packet((int)ClientPackets.updateProfileDetails))
        {
            _packet.Write(Client.instance.username);
            _packet.Write(_firstName);
            _packet.Write(_lastName);
            _packet.Write(_tagline);
            SendTCPData(_packet);

        }
    }

    public static void UpdateAttributes(bool[] _toggleValues)
    {
        using (Packet _packet = new Packet((int)ClientPackets.updateAttributes))
        {
            _packet.Write(Client.instance.username);
            foreach (bool _toggleValue in _toggleValues )
            {
                _packet.Write(_toggleValue);
            }
            SendTCPData(_packet);

        }
    }

    /*
    public static void RequestAvaliableQuests()
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestAvaliableQuests))
        {
            _packet.Write(Client.instance.username);
            SendTCPData(_packet);

        }
    }

    public static void RequestActiveQuests()
    {
        using (Packet _packet = new Packet((int)ClientPackets.requestActiveQuests))
        {
            _packet.Write(Client.instance.username);
            SendTCPData(_packet);

        }
    }

    

    public static void AddQuest(int _questId)
    {
        using (Packet _packet = new Packet((int)ClientPackets.addQuest))
        {
            _packet.Write(_questId);
            SendTCPData(_packet);

        }
    }

    public static void AdvanceQuest(int _questId, int _completedQuestStep)
    {
        //Debug.Log("SENDING ADVANCE QUEST REQUEST for ID: " + _questId + " and step: " + _completedQuestStep);
        Debug.Log("Clienct conneceted = " + Client.instance.isConnected);
        Client.instance.ConnectToServer();
        using (Packet _packet = new Packet((int)ClientPackets.advanceQuest))
        {
            _packet.Write(_questId);
            _packet.Write(_completedQuestStep);
            SendTCPData(_packet);

        }
    }

    public static void QuestFinished(int _questId)
    {
        using (Packet _packet = new Packet((int)ClientPackets.questFinished))
        {
            _packet.Write(_questId);
           SendTCPData(_packet);

        }
    }

    public static void RemoveQuest(int _questId)
    {
        using (Packet _packet = new Packet((int)ClientPackets.removeQuest))
        {
            _packet.Write(_questId);
            SendTCPData(_packet);

        }

    }

    */
   

    #endregion
}
