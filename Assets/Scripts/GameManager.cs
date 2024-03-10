using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 public NPCBehavior npc; // Reference to the NPC script
    public Scoring scoringSystem; // Reference to the Scoring system script
    [SerializeField] ScaleScript scale;
    
    private int targetScore = 250; // Example target score
    
    void Update()
    {
if (Input.GetKeyDown(KeyCode.W))
{
    // Assign a random value to the NPC for scoring purposes
    npc.AssignRandomValue(100, 400); // Example range
    npc.UpdateText(npc.randomValue.ToString());
    Debug.Log("Yo the target score is " + npc.randomValue);
}

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Calculate and log the score based on the NPC's random value
            int score = scoringSystem.CalculateScore(scale.GetList().Count, npc.randomValue);
            Debug.Log("u gave me " + scale.GetList().Count + "But I asked for " + npc.randomValue + "...Keep the change fool... " + score);
            scale.ResetScales();
        }
    }
}

