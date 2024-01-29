using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public GameObject mainCamera;   
    public float speed;
    private bool isActive = false;

    
    private Touch touch;
    
    
    public void Activate()
    {
        GameManager.instance.mapManager.SetTransformTarget(gameObject);
        mainCamera.SetActive(false);
        transform.position = GameManager.instance.player.transform.position;
        isActive = true;
    }

    public void DeActivate()
    {
        isActive = false;
       
        GameManager.instance.mapManager.SetTransformTarget(GameManager.instance.player.gameObject);
        mainCamera.SetActive(true);
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (isActive)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * speed,
                        transform.position.y,
                        transform.position.z + touch.deltaPosition.y * speed

                        );

                }
            }
            
        }
        

    }
}
