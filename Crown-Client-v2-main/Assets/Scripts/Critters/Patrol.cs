using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    
    [SerializeField] float minRange = .5f;
    [SerializeField] float maxRange = 2.5f;
    [SerializeField] float speed = 2f;
    private Animator critterAnimator;
    private int currentWaypoint;
    private Vector3 startPosition;
    private Vector3[] waypoints;
    private float waitTime;
    private float waitCounter = 0f;
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        critterAnimator = GetComponent<Animator>();
        startPosition = transform.position;
        waypoints = new Vector3[10];
        for(int i = 0; i <= 9; i++)
        {
            waypoints[i] = GetPatrolWaypoint();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            
            if (waitCounter < waitTime)
            {
                return;
            }

            
            
            waiting = false;

        }
        
        Vector3 _targetWaypoint = waypoints[currentWaypoint];

        if (Vector3.Distance(transform.position, _targetWaypoint) < 0.01f)
        {
            
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            transform.position = _targetWaypoint;
            waitTime = Random.Range(0f, 10f);
            critterAnimator.SetBool("isMoving", false);
            if (waitTime > 6f)
            {
                critterAnimator.SetBool("isSleeping", true);
            } else
            {
                critterAnimator.SetBool("isSleeping", false);
            }
            waitCounter = 0f;
            waiting = true;
            


        } else
        {

            if (critterAnimator.GetBool("isSleeping"))
            {
                critterAnimator.SetBool("isSleeping", false);
            }
            critterAnimator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, _targetWaypoint, speed * Time.deltaTime);
            transform.LookAt(_targetWaypoint);
            
            

        }
    }

    Vector3 GetPatrolWaypoint()
    {
        return new Vector3(startPosition.x + GenerateRange(), startPosition.y, startPosition.z + GenerateRange());
    }

    private float GenerateRange()
    {
        float _randomNum = Random.Range(minRange, maxRange);
        bool _isPositive = Random.Range(0, 10) < 5;

        return _randomNum * (_isPositive ? 1 : -1);
    }
}
