using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float boundaryLeft = -5f;
    public float boundaryRight = 5f;
    public Transform targetPosition; // Assign the camera or a specific point you want the NPC to move towards
    public float stopDistance = 20f; // Distance from the target position to stop

    private bool isTriggered = false;

    void Update()
    {
        if (!isTriggered)
        {
            // NPC Idle movement: Move between boundaries
            IdleMovement();
        }

        // When W is pressed, trigger the NPC to move towards the target position
        if (Input.GetKeyDown(KeyCode.W))
        {
            isTriggered = true;
        }

        if (isTriggered)
        {
            // Face the camera/target and move towards it until reaching the stop distance
            FaceTarget();
            MoveTowardsTarget();
        }
    }

    void IdleMovement()
    {
        float step = moveSpeed * Time.deltaTime;
        float targetX = Mathf.PingPong(Time.time * moveSpeed, boundaryRight - boundaryLeft) + boundaryLeft;
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }

    void FaceTarget()
    {
        Vector3 directionToTarget = targetPosition.position - transform.position;
        directionToTarget.y = 0; // Keep the NPC upright, ignore the y-axis difference
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
    }

    void MoveTowardsTarget()
    {
        // Stop moving towards the target if within stopDistance on the z-axis
        if (Vector3.Distance(transform.position, targetPosition.position) <= stopDistance)
            return;

        // Move directly towards the target position at moveSpeed
        Vector3 moveDirection = (targetPosition.position - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
