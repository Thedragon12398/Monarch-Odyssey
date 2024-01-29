using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    
    //dictionary to store players
    //might be needed later if we decide to display other players on map
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public MapManager mapManager;
    public MapCamera mapCamera;
    public QuestManager questManager;
    public PlayerController playerController;
    public PlayerManager player;
    public GameSceneUIManager uiManager;

    //records the state of the game
    //0 = base state
    //1 = overhead map open
    private int gameState = 0;


    private void Awake()
    //initialize the game manager singleton upon waking up
    {

        
    }

    private void Start()
    {
        //initially set this command to block 
        //ClientSend.AddQueueCommand(new SendStuffCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //ClientSend.AddQueueCommand(new RequestActiveQuestsCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        //ClientSend.AddQueueCommand(new RequestAvaliableQuestsCommand());
        //ClientSend.AddQueueCommand(new SpawnCrittersCommand(false));
    }

    public void SpawnPlayer(int _xp, int _energyCarried)
    {
        Debug.Log($"Spawn player called");
        player.setXP(_xp);
        player.setEnergyCarried(_energyCarried);

    }

    public void PopulateGameScene()
    {
        //initially set this command to block 
        ClientSend.AddQueueCommand(new SendStuffCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        ClientSend.AddQueueCommand(new RequestActiveQuestsCommand());
        //ClientSend.AddQueueCommand(new BlockingCommand());
        ClientSend.AddQueueCommand(new RequestAvaliableQuestsCommand());
        //ClientSend.AddQueueCommand(new SpawnCrittersCommand(false));
    }

    public void DisplayOverHeadMap()
    {

        //set gameState to 1
        gameState = 1;

        //activate the mapCamera's game object and call its activate method.
        mapCamera.gameObject.SetActive(true);
        mapCamera.Activate();
        //scale the map markers up
        //TODO figure out what markers to scale up and how
        mapManager.ScaleMarkers(10);

        Client.instance.Disconnect();


    }

    public void CloseOverHeadMap()
    {
        //set gameState to 0
        gameState = 0;

        //call the mapCamera's deactivate method and deactivate its gameobject;
        mapCamera.DeActivate();
        mapCamera.gameObject.SetActive(false);

        //scale the map markers down
        mapManager.ScaleMarkers(1);

    }
    public void ChangeScene(string _sceneName)
    {
        //SceneLoader.Load((int)SceneNames._scene);
        //SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }

    public int returnGameState()
    {
        return gameState;
    }
}
