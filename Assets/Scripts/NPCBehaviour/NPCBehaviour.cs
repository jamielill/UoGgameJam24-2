using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float idleMoveSpeed = 2f; // Speed for idle movement left to right.
    public float approachSpeed = 3f; // Speed when approaching the player.
    public Transform targetPosition; // Target to approach, typically the camera/player.
    private bool isMovingToCamera = false; // Indicates whether the NPC is moving towards the camera.
    private float leftBound = -5f; // Left boundary for idle movement.
    private float rightBound = 5f; // Right boundary for idle movement.
    private float direction = 1f; // Direction of movement, 1 for right, -1 for left.

    void Start()
    {
        if (targetPosition == null)
        {
            targetPosition = Camera.main.transform; // Default to main camera if not set.
        }
    }

    void Update()
    {
        if (!isMovingToCamera)
        {
            IdleMovement();
        }
        else
        {
            MoveTowardsCamera();
        }

        // Check for input to start moving towards the camera.
        if (Input.GetKeyDown(KeyCode.W))
        {
            isMovingToCamera = true;
        }
    }

    void IdleMovement()
    {
        // Move left and right between the bounds.
        if(transform.position.x >= rightBound || transform.position.x <= leftBound)
        {
            direction *= -1; // Change direction at bounds.
        }
        transform.position += new Vector3(idleMoveSpeed * direction * Time.deltaTime, 0, 0);
    }

    void MoveTowardsCamera()
    {
        // Move directly towards the camera
        Vector3 moveDirection = (targetPosition.position - transform.position).normalized;
        // Optionally ignore the y component to keep movement horizontal.
        moveDirection.y = 0;
        transform.position += moveDirection * approachSpeed * Time.deltaTime;
    }
}
