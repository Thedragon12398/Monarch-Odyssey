using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCreature : MonoBehaviour
{
    [SerializeField] float minTimeBeforeExpires = 120;
    [SerializeField] float maxTimeBeforeExpires = 300;
    private float expirationTime;
    // Start is called before the first frame update
    void Start()
    {
        expirationTime = Random.Range(minTimeBeforeExpires, maxTimeBeforeExpires);
    }

    // Update is called once per frame
    void Update()
    {
        expirationTime -= Time.deltaTime;
        if (expirationTime < 0)
        {
            CritterFactory.instance.RemoveCritter(gameObject);            
        }
    }
}