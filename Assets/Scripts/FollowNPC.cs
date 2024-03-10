using UnityEngine;

public class FollowNPC : MonoBehaviour
{
    public Transform target; // Assign the NPC/player Transform in the Inspector
    public Vector3 offset = new Vector3(0, 2, 0); // Adjust this offset as needed

    void Update()
    {
        if (target != null)
        {
            // Update the position of the text to follow the target, with an offset if desired
            transform.position = target.position + offset;
        }
    }
}