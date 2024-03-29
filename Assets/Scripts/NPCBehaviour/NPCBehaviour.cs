using UnityEngine;
using System.Collections;
using TMPro;

public class NPCBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform targetPosition;
    private bool isApproaching = false;
    private bool isLeaving = false;
    private Coroutine leaveRoutine = null;
    public Sprite[] sprites; // Assign this array in the Inspector with your 5 sprites
    private SpriteRenderer spriteRenderer;


    public int randomValue; 
 private void Awake()
    {
        targetPosition = Camera.main.transform;
        
        // Get the SpriteRenderer component and assign a random sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (sprites != null && sprites.Length > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        }
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

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(targetPosition.position.x, 0, targetPosition.position.z)) <= 6f)
        {
            isApproaching = false;
            leaveRoutine = StartCoroutine(WaitAndLeave(30f)); // Wait for 5 seconds then leave
        }
    }

    IEnumerator WaitAndLeave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isLeaving = true;
    }

    public void AssignRandomValue(int minValue, int maxValue)
    {
        randomValue = Random.Range(minValue, maxValue);
        Debug.Log($"NPC's Random Value: {randomValue}");
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

    public void UpdateText(string text)
{
    var tmpText = GetComponentInChildren<TextMeshProUGUI>(); // Or TextMeshPro for 3D text
    if (tmpText != null)
    {
        tmpText.text = text;
    }
}


    private void Leave()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (transform.position.x > 30) // Assumes 30 units is off-screen.
        {
            Destroy(gameObject);
        }
    }
}
