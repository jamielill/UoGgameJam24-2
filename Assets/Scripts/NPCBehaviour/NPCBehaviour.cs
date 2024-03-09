using UnityEngine;
using System.Collections;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform targetPosition;
    private bool isApproaching = false;
    private bool isLeaving = false;
    private Coroutine leaveRoutine = null;

    private void Awake()
    {
        targetPosition = Camera.main.transform;
    }

    private void Update()
    {
        if (isApproaching)
        {
            Approach();
        }
        else if (isLeaving)
        {
            Leave();
        }
    }

    public void BeginApproach()
    {
        if (!isApproaching)
        {
            isApproaching = true;
            isLeaving = false;
            if (leaveRoutine != null)
            {
                StopCoroutine(leaveRoutine);
                leaveRoutine = null;
            }
        }
    }

    private void Approach()
    {
        Vector3 direction = (new Vector3(targetPosition.position.x, 0, targetPosition.position.z) - new Vector3(transform.position.x, 0, transform.position.z)).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.position.x, 0, targetPosition.position.z)) <= 5f)
        {
            isApproaching = false;
            leaveRoutine = StartCoroutine(WaitAndLeave(5f)); // Wait for 5 seconds then leave
        }
    }

    IEnumerator WaitAndLeave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isLeaving = true;
    }

    public void BeginLeaving()
    {
        if (!isLeaving)
        {
            isLeaving = true;
            isApproaching = false;
            if (leaveRoutine != null)
            {
                StopCoroutine(leaveRoutine);
                leaveRoutine = null;
            }
        }
    }

    private void Leave()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (transform.position.x > 30) // Assumes 30 units is off-screen for your setup.
        {
            Destroy(gameObject);
        }
    }
}