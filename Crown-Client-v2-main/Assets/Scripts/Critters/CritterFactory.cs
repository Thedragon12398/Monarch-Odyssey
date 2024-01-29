using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CritterFactory : MonoBehaviour
{
    public static CritterFactory instance;
    public GameObject critterContainer;
    
    [SerializeField] private GameObject[] avaliableCritters;
    [SerializeField] private float waitTime = 180.0f; //how long in seconds factory waits before spawning a critter centered on the player
    [SerializeField] private int maxCritters = 21; //the maximum number of critters possible unfer all circumstances
    [SerializeField] private float minRange = 5.0f; //min range a critter can spawn to a target
    [SerializeField] private float maxRange = 50.0f; //max range a critter can spawn from a target
    [SerializeField] private float exclusionRange = 25; //the distance to test for critters around new spawn target
    [SerializeField] private int crittersAllowedinExclusionRange = 5; //total number of critters allowed around a target


    private void Awake()
    //initialize the singleton upon waking up

    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance alreasy exists; destroying object!");
            Destroy(this);
        }

        //DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(avaliableCritters);
        
    }

    private void Start()
    {
        //start the coroutine that spawns critters around player.
        StartCoroutine(GenerateCritters());
    }

    //called when quest markers are added to populate the map with critters
    public void SpawnCritters(Vector3 _targetPosition)
    {
       //first check to see how many critters are already in range of the marker
        int _critterCount = 0;
        foreach (Transform _child in critterContainer.transform)
        {
            if (Vector3.Distance(_targetPosition, _child.position) <= exclusionRange)
            {
                _critterCount++;
            }

            //if the max has been reached, return
            if (_critterCount >= crittersAllowedinExclusionRange)
            {
                return;
            }
        }

        //randomly spawn critters based on difference between how many are in range and the max number
        //might need to think of better way
        int _maxSpawnNumber = crittersAllowedinExclusionRange - _critterCount;
        int _crittersToSpawn = Random.Range(1, _maxSpawnNumber);

        for (int i = 0; i < _crittersToSpawn; i++)
        {
            if (critterContainer.transform.childCount <= maxCritters)
            {
                InstantiateCritter(_targetPosition);
            }
        }
        
    }

    private IEnumerator GenerateCritters()
    {
        while (true)
        {
            InstantiateCritter(GameManager.instance.player.transform.position);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void InstantiateCritter(Vector3 _targetPosition)
    {
        
        int _index = Random.Range(0, avaliableCritters.Length);
        float _x = _targetPosition.x + GenerateRange();
        float _y = _targetPosition.y;
        float _z = _targetPosition.z + GenerateRange(); 

        GameObject _critter = Instantiate(avaliableCritters[_index], new Vector3(_x, _y, _z), Quaternion.identity);
        _critter.transform.parent = critterContainer.transform;


    }

    private float GenerateRange()
    {
        float _randomNum = Random.Range(minRange, maxRange);
        bool _isPositive = Random.Range(0, 10) < 5;

        return _randomNum * (_isPositive ? 1 : -1);
    }

    public void RemoveCritter(GameObject _critter)
    {
        Destroy(_critter);
    }

    
    
}
