using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPlatform : MonoBehaviour
{

    public Vector3[] travelPoints;
    private Vector3 travel_end;
    public int travel_point = 0;

    public float speed;
    public float delay;
    public float tolerance;

    private float delay_start;

    public bool automatic;


    // Start is called before the first frame update
    void Start()
    {
        if (travelPoints.Length > 0)
        {
            travel_end = travelPoints[0];
        }

        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != travel_end)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
    }

    void MovePlatform()
    {
        Vector3 heading = travel_end - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;

        if (heading.magnitude < tolerance)
        {
            transform.position = travel_end;
            delay_start = Time.time;
        }
    }

    void UpdateTarget()
    {
        if (automatic)
        {
            if (Time.time - delay_start > delay)
            {
                NextPlatform();
            }
        }
    }

    public void NextPlatform()
    {
        travel_point++;
        if (travel_point >= travelPoints.Length)
        {
            travel_point = 0;
        }
        travel_end = travelPoints[travel_point];
    }
}
