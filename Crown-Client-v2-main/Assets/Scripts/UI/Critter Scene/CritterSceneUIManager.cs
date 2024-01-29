using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterSceneUIManager : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    public void ExitScene()
    {
        //turn main camera off before switching scenes so as not to get conflict between two audio listeners
        mainCamera.gameObject.SetActive(false);
        GameManager.instance.UnloadScene("CritterEncounter");
    }
}
