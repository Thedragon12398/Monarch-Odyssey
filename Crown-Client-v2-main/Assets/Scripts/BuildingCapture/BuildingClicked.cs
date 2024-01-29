using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingClicked : MonoBehaviour, IDragHandler
{
    public Transform Building;
    public BuildingInfoPanel buildingInfoPanel;
    // Main game camera
    public Camera mainCamera;
    // Info panel camera
    public Camera infoPanelCamera;

    public void OnMouseDown()
    {
        //if overhead map is on and player clicks on waypoint, display active quest details window
        if(gameObject.tag == "QuestMarker")
        {
            //This was already here, I assume CritterEncounter is a future scene, so I just created an empty one for now
           // Debug.Log(gameObject.name + " Clicked!");
            GameManager.instance.ChangeScene("CritterEncounter");
            SceneLoader.Load(SceneNames.CritterEncounter);
        }
        else if(gameObject.tag == "Building")
        {
            buildingInfoPanel.title.text = gameObject.name.ToString();
            //buildingInfoPanel.info.text = buildingInfoManager(gameObject.name.toString());
            buildingInfoPanel.gameObject.SetActive(true);
            //Disable main camera movement
            mainCamera.gameObject.SetActive(false);
            infoPanelCamera.gameObject.SetActive(true);
        }
        
    }

    
    public void OnDrag(PointerEventData eventData){
        //Building.eulerAngles += new Vector3(eventData.delta.y, eventData.delta.x);
        Building.transform.Rotate(0f, eventData.delta.x * .50f, 0f, Space.Self);
    }

}


