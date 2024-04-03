using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] buttons;

    float fishTimer = 0f;
    enum States { 
        Inactive,
        WaitingForFish,
        FishOnHook,
        FishLost,
        FishCaught
    }

    States currentState = States.WaitingForFish;

    bool lineIsActive = false;

    private void Update() {
        if (currentState == States.WaitingForFish) {
            Debug.Log("Waiting for fish");
            FindFish();
        }
    }
    public void CastLine() {
        currentState = States.WaitingForFish;
    }
    public void WithdrawLine() {
        currentState = States.Inactive;
        Debug.Log("Withdrew line");
    }
    void FindFish() {
        if (fishTimer == 0) {
            fishTimer = Random.Range(1, 10);
        }
    }
}
