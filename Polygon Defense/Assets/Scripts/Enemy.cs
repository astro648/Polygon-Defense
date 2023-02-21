using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        // Check if there are any waypoints defined
        if (Waypoints.points == null || Waypoints.points.Length == 0)
        {
            Debug.LogError("No waypoints defined!");
            return;
        }

        target = Waypoints.points[0];
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Vector3 is 3 numbers that represent x, y, and z
        Vector3 dir = target.position - transform.position; // This will give us our direction vector
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); // Time.deltaTime will make sure that the speed that we move at is not dependent on framerate

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (Waypoints.points == null || Waypoints.points.Length == 0)
        {
            Debug.LogError("No waypoints defined!");
            return;
        }

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
