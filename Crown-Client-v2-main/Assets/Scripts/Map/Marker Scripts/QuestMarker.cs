using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class QuestMarker : MonoBehaviour
{
    //this script controls mouse click behavior on quest markers
    private int questID;
    
    public void Initialize(int _id)
    {
        questID = _id;
    }    

    public void OnMouseDown()
    {
        GameManager.instance.uiManager.DisplayQuestDetails(questID);
    }
}
