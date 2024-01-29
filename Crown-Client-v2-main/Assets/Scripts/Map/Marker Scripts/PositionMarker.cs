using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class PositionMarker : MonoBehaviour
{
    private Vector2d markerPos;
    public bool scalable = true; //should the object be scaled in overhead map view?
    public float rotateOnScaleValue; //set on the prefab, determines if and how much to rotate the marker up in overhead map view
    
    public void initialize (string _position)
    {
        markerPos = Conversions.StringToLatLon(_position);
        AbstractMap _map = GameManager.instance.mapManager.map;
        transform.localPosition = _map.GeoToWorldPosition(markerPos, true);
    }

    // Update is called once per frame
    void Update()
    {
        AbstractMap _map = GameManager.instance.mapManager.map;
        transform.localPosition = _map.GeoToWorldPosition(markerPos, true);

    }

    public void ScaleMe(float _value)
    {
        if (!scalable)
        {
            return;
        }
        
        transform.localScale = new Vector3(_value, _value, _value);

        if (_value > 1)
        {
            transform.localRotation = Quaternion.Euler(rotateOnScaleValue, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

    

