using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNavMesh : MonoBehaviour
{
    public float speed = 4f; // Speed for idle movement left to right.    
    public Transform targetPosition; // Target to approach, typically the camera/player.
    private float leftBound = -5f; // Left boundary for idle movement.
    private float rightBound = 5f; // Right boundary for idle movement.
    private float direction = 1f; // Direction of movement, 1 for right, -1 for left.
    private bool isMoving = false;

    public Transform[] waypoints; // Array of points cubes follows
    public Transform[] waypointsBack; // Array of points cubes follows
    private int currentWaypoint = 0; // Index of current waypoint

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            IdleMovement();
        }
        else
        {
            // If "W" is pressed and NPC is not moving, move along waypoints
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveAlongWaypoints(waypoints);
            }
            // If "S" is pressed and NPC is not moving, move back along waypointsBack
            else if (Input.GetKeyDown(KeyCode.S))
            {
                MoveAlongWaypoints(waypointsBack);
            }
        }
    }

    void IdleMovement()
    {
        // Move left and right between the bounds.
        /*if (transform.position.x >= rightBound || transform.position.x <= leftBound)
        {
            direction *= -1; // Change direction at bounds.
        }
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);*/
    }

    // Move along the provided waypoints
    void MoveAlongWaypoints(Transform[] waypointsToFollow)
    {
        if (Vector3.Distance(transform.position, waypointsToFollow[currentWaypoint].position) < 0.1f)
        {
            // Move to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypointsToFollow.Length;
        }
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypointsToFollow[currentWaypoint].position, speed * Time.deltaTime);
    }
}