using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSphere : MonoBehaviour
{
    public static int currentScore;
  
    DataScript data;
    
    [SerializeField] 
    GameObject BoxPoint;

    void Start()
    {
        data = BoxPoint.GetComponent<DataScript>();
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            ///gets rid of point on click
            data.pointPrefab.SetActive(false);

            data.newPoint.SetActive(true);
            
            currentScore++;

        }
    }
}
