using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    DrawingGameBehavior dgb;

    public GameObject pointPrefab;
    public GameObject newPoint;

    void Start()
    {
        ///disable at start
        pointPrefab.SetActive(false);  

        newPoint.SetActive(false);
    }
    
    void Update()
    {
        ///disable new sphere after it complates the shape
       /* if (dgb.GetComponent<DrawingGameBehavior>().square == true)
        {
            newPoint.SetActive(false);
        }
        if (dgb.GetComponent<DrawingGameBehavior>().triangle == true)
        {
            newPoint.SetActive(false);
        }
        if (dgb.GetComponent<DrawingGameBehavior>().star == true)
        {
            newPoint.SetActive(false);
        }*/
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ///spawn point prefab once croc gets close to the waypoint
            pointPrefab.SetActive(true);
        }
    }
    
    
}
