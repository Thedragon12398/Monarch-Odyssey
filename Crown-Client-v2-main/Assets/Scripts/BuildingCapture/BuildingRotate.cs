using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRotate : MonoBehaviour
{
    public Transform Building;
    public float radius;


    void Update()
    {
        transform.position = Building.position - (transform.forward * radius);
        transform.RotateAround(Building.position, Vector3.up, Input.GetAxis("Mouse X"));
        transform.RotateAround(Building.position, transform.right, Input.GetAxis("Mouse Y"));
    }
}
