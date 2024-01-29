using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//derived from the mapbox Astronaut Game example.

public class PlayerMovement : MonoBehaviour
    
{
    public PlayerController characterController;
    public Transform GPSTarget;
    public float speed;
    public Animator characterAnimator;
    
    void Start()
    {
        characterController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if the client is in editor mode; if so move the character idependently of GPS
        //and mapbox location provider
        if (characterController.enabled)
        {
            return;
        }

        //in GPS mode, mapbox uses unity's location data to move an empty game object, which the player's object follows along.
        var distance = Vector3.Distance(transform.position, GPSTarget.position);
        if (distance > 0.1f)
        {
            transform.LookAt(GPSTarget.position);
            transform.Translate(Vector3.forward * speed);
            characterAnimator.SetBool("isMoving", true);
        }
        else
        {
            characterAnimator.SetBool("isMoving", false);
        }
    }
}

