using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrollingAI : MonoBehaviour
{
    public Transform[] waypoints;
    public int speed;


    private int wayPointIndex;
    private float dist;


    void Start()
    {
        wayPointIndex = 0;
        transform.LookAt(waypoints[wayPointIndex].position);
    }

    void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void increaseIndex()
    {
        wayPointIndex++;
        if (wayPointIndex >= waypoints.Length)
            wayPointIndex = 0;

        transform.LookAt(waypoints[wayPointIndex].position);
    }


    // Update is called once per frame
    void Update()
    {

        dist = Vector3.Distance(transform.position, waypoints[wayPointIndex].position);
        if (dist < 1f)
            increaseIndex();

        patrol();
    }
}
