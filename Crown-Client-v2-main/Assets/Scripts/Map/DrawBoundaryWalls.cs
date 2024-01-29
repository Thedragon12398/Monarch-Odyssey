using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Unity.Map;

//this script draws invisible boundary walls around the limits of the map

public class DrawBoundaryWalls : MonoBehaviour
{

    private Vector2d[] wallMarkerLocations;
    private Vector3[] boundaryLinePoints;
    private string[] wallMarkerLocationStrings = new string[] {
        "36.882111134662495, -76.2983228652274", //corner of 41st and Killiam
        "36.8820079756071, -76.3022071188787",
        "36.883367236686446, -76.30248023046354",
        "36.88300921936636, -76.31244121668337",
        "36.88021177201623, -76.31227431515208",
        "36.880187498706114, -76.3134881444181",
        "36.88140115477367, -76.31521785105474",
        "36.88317759694771, -76.31526349597753",
        "36.883692489796886, -76.31439446023602",
        "36.88491104584225, -76.31452324746132",
        "36.88482523197802, -76.31684067610539",
        "36.88651568083435, -76.31930828793439", //point out in water by sailing center
        "36.88664439784109, -76.31277444010956",
        "36.88740810173457, -76.31275294375291",
        "36.887648350379074, -76.30595081920171",
        "36.88912431038073, -76.30601517444337",
        "36.89052295512848, -76.30493158895761",
        "36.891200856235606, -76.3049101437527",
        "36.89121804127734, -76.3041376252107",
        "36.88924439969652, -76.30313981964827",
        "36.887759870740624, -76.30285012284497",
        "36.887845690496256, -76.29795775206577",
        "36.88567974193749, -76.29837897688222",
        "36.88493311363222, -76.29844605365017",
        "36.88353083840265, -76.2983955011459",
        "36.882111134662495, -76.2983228652274" //corner of 41st and Killiam
    };

    
    public GameObject wallSegmentPrefab;

    //public LineRenderer _mapBorder;
    
    public AbstractMap _map;
    public float _spawnScale;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < wallMarkerLocationStrings.Length; i++)
        {
           
            
            GameObject _segment = Instantiate(wallSegmentPrefab);
            BoundaryWallSegment _segmentControl = _segment.GetComponent<BoundaryWallSegment>();
            if (i != wallMarkerLocationStrings.Length - 1)
            {
                _segmentControl.BuildWallSegment(wallMarkerLocationStrings[i], wallMarkerLocationStrings[i + 1]);
            } 

            _segment.transform.parent = gameObject.transform;

            


        }

        
        
    }
    
}
