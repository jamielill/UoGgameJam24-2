using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab;
    private List<NPCBehavior> npcs = new List<NPCBehavior>();
    private NPCBehavior currentNPC;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnNPC();
        }

        if (Input.GetKeyDown(KeyCode.W) && currentNPC == null)
        {
            ActivateNPC();
        }

        if (Input.GetKeyDown(KeyCode.E) && currentNPC != null)
        {
            currentNPC.BeginLeaving();
            currentNPC = null; // Allow a new NPC to be activated.
        }
    }

    void SpawnNPC()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, 10); // Customize as needed
        GameObject npcObject = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
        NPCBehavior npcBehavior = npcObject.GetComponent<NPCBehavior>();
        npcs.Add(npcBehavior);
    }

    void ActivateNPC()
    {
        if (npcs.Count > 0)
        {
            currentNPC = npcs[0];
            currentNPC.BeginApproach();
            npcs.RemoveAt(0); // Remove the NPC from the list to prevent reactivation.
        }
    }
}
