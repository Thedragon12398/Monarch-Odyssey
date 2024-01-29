using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Map.TileProviders;

public class MapManager : MonoBehaviour
{
    //this script stores and interacts with mapbox components
    public AbstractMap map;
    public GameObject questMarkerPrefab;
    public GameObject questWaypointMarkerPrefab;
    //empty gameobject that stores quest markers
    public GameObject questMarkers;    

    //changes the map's transform target depending which mode the map is in
    //in normal mode, the transform target is the player
    //in overhead map mode, it is the empty gameobject players use to scroll the map
    public void SetTransformTarget(GameObject _target)
    {
        RangeAroundTransformTileProviderOptions mapOptions = (RangeAroundTransformTileProviderOptions)map.Options.extentOptions.GetTileProviderOptions();
        mapOptions.targetTransform = _target.transform;        
    }

    //adds a marker to indicate an avaliable quest.
    public PositionMarker AddQuestMarker(int _id, string _position)
    {
        //instantiate the quest marker
        GameObject _questMarker = Instantiate(questMarkerPrefab);
        //move it to the marker container
        _questMarker.transform.parent = questMarkers.transform;
        //configure the quest marker
        QuestMarker _questScript = _questMarker.GetComponent<QuestMarker>();
        _questScript.Initialize(_id);
        PositionMarker _markerScript = _questMarker.GetComponent<PositionMarker>();
        _markerScript.initialize(_position);

        CritterFactory.instance.SpawnCritters(_questMarker.transform.position);


        return _markerScript;
    }

    //adds a marker to indicate a quest's waypoint.
    public PositionMarker AddQuestWaypointMarker(QuestClass _quest, string _position)
    {
        //instantiate the quest marker
        GameObject _waypointMarker = Instantiate(questWaypointMarkerPrefab);
        //move it to the marker container
        _waypointMarker.transform.parent = questMarkers.transform;
        //configure the quest marker
        QuestWaypoint _waypointScript = _waypointMarker.GetComponent<QuestWaypoint>();
        _waypointScript.Initialize(_quest);
        PositionMarker _markerScript = _waypointMarker.GetComponent<PositionMarker>();
        _markerScript.initialize(_position);

        if (GameManager.instance.returnGameState() == 1)
        {
            _markerScript.ScaleMe(10);
        }

        CritterFactory.instance.SpawnCritters(_waypointMarker.transform.position);

        return _markerScript;
    }

    //scales the map markers with the mapmode
    public void ScaleMarkers(float _value)
    {
        foreach (QuestClass _quest in GameManager.instance.questManager.avaliableQuests)
        {
            _quest.markerScript.ScaleMe(_value);
        }

        foreach (QuestClass _quest in GameManager.instance.player.currentQuests)
        {
            _quest.markerScript.ScaleMe(_value);
        }
    }


    
}
