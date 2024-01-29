using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Unity.Map;
public class BoundaryWallSegment : MonoBehaviour
{
    
    public GameObject firstMarkerPrefab;
    public GameObject secondMarkerPrefab;
    public GameObject boundaryWallPrefab;

    private Vector2d firstMarkerPos;
    private Vector2d secondMarkerPos;

    private AbstractMap map;

    public float spawnScale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        AbstractMap _map = GameManager.instance.mapManager.map;
        firstMarkerPrefab.transform.localPosition = _map.GeoToWorldPosition(firstMarkerPos, true);
        secondMarkerPrefab.transform.localPosition = _map.GeoToWorldPosition(secondMarkerPos, true);
        ConfigureWallSegment();
    }

    public void BuildWallSegment(string _startGPS, string _endGPS)
    {

        AbstractMap _map = GameManager.instance.mapManager.map;
        firstMarkerPos = Conversions.StringToLatLon(_startGPS);
        firstMarkerPrefab.transform.localPosition = _map.GeoToWorldPosition(firstMarkerPos, true);
        //firstMarkerPrefab.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);

        secondMarkerPos = Conversions.StringToLatLon(_endGPS);
        secondMarkerPrefab.transform.localPosition = _map.GeoToWorldPosition(secondMarkerPos, true);
        //secondMarkerPrefab.transform.localScale = new Vector3(spawnScale, spawnScale, spawnScale);

        ConfigureWallSegment();
    }

    private void ConfigureWallSegment()
    {
        Vector3 _firstMarketTarget = new Vector3(secondMarkerPrefab.transform.position.x, firstMarkerPrefab.transform.position.y, secondMarkerPrefab.transform.position.z);
        Vector3 _secondMarketTarget = new Vector3(firstMarkerPrefab.transform.position.x, secondMarkerPrefab.transform.position.y, firstMarkerPrefab.transform.position.z);


        firstMarkerPrefab.transform.LookAt(_firstMarketTarget);
        secondMarkerPrefab.transform.LookAt(_secondMarketTarget);
        

        float _distance = Vector3.Distance(firstMarkerPrefab.transform.position, secondMarkerPrefab.transform.position);
        boundaryWallPrefab.transform.position = firstMarkerPrefab.transform.position + _distance / 2 * firstMarkerPrefab.transform.forward;
        boundaryWallPrefab.transform.rotation = firstMarkerPrefab.transform.rotation;
        boundaryWallPrefab.transform.localScale = new Vector3(boundaryWallPrefab.transform.localScale.x, boundaryWallPrefab.transform.localScale.y, _distance);

    }
}
