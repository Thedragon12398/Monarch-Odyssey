using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackerMovement : MonoBehaviour
{
    public static StackerMovement instance;

    private float mousePos;

    public int stacked = 0;
    
    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        mousePos = Mathf.Clamp(Input.mousePosition.x, 35.5f, 250f);

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos, 50f, 10f));

        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Acorn 1(Clone)" || collision.gameObject.name == "Apple 1(Clone)")
        {
            Destroy(collision.gameObject);
            stacked++;
        }
    }
}
