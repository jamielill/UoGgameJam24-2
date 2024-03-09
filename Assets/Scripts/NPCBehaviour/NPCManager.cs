using UnityEngine;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour
{
    //public Transform[] queuePositions;//array for queue pos

    public GameObject[] npcPrefabs; // Array to hold NPC prefabs
    private static List<NPCBehavior> idleNPCs = new List<NPCBehavior>();
    private static bool isAnyNPCActive = false;
    

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            CreateRandomNPC();
        }
        
        if (Input.GetKeyDown(KeyCode.W) && !isAnyNPCActive)
        {
            TryActivateNPC();
        }
    }*/

    //Queing start
    /*void Start()
    {
        // Instantiate NPCs at queue positions.
        foreach (Transform position in queuePositions)
        {
            foreach (GameObject prefab in npcPrefabs)
            {
                Instantiate(prefab, position.position, position.rotation);
            }
        }
    }*/
    //Queing end

    public void CreateRandomNPC()
    {
        if (npcPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, npcPrefabs.Length);
        GameObject npcPrefab = npcPrefabs[randomIndex];
        Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        Instantiate(npcPrefab, spawnPosition, Quaternion.identity);
    }

    public static void RegisterIdleNPC(NPCBehavior npc)
    {
        if (!idleNPCs.Contains(npc))
        {
            idleNPCs.Add(npc);
        }
    }

    public static void UnregisterIdleNPC(NPCBehavior npc)
    {
        idleNPCs.Remove(npc);
    }

    /*public static void TryActivateNPC()
    {
        if (isAnyNPCActive || idleNPCs.Count == 0) return;

        int randomIndex = Random.Range(0, idleNPCs.Count);
        idleNPCs[randomIndex].Activate();
        isAnyNPCActive = true;
    }*/

    public static void NPCDeactivated()
    {
        isAnyNPCActive = false;
    }
    public static void NPCActivated()
    {
    isAnyNPCActive = true;
    }

}
