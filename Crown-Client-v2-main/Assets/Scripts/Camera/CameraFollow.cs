using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// based on https://www.youtube.com/watch?v=pyb3cKrj1ZE
/// </summary>
public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 cameraOffset;
    public float smoothFactor = 0.5f;
    public bool lookAtTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - cameraTarget.transform.position;
    }

    // Late Update called after everything else has been rendered
    void LateUpdate()
    {
        Vector3 newPosition = cameraTarget.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position,newPosition, smoothFactor);

        if(lookAtTarget)
        {
            transform.LookAt(cameraTarget);
        }
    }
}
