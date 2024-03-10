using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
 public int CalculateScore(int playerScore, int targetScore)
{
    float maxDifferencePercent = 30f; // Maximum percentage difference allowed
    int maxScore = 100; // Maximum score attainable
    
    // Calculate the raw percentage difference
    float rawPercentDifference = (float)(playerScore - targetScore) / targetScore * 100;
    // Calculate the absolute percentage difference
    float percentDifference = Mathf.Abs(rawPercentDifference);
    
    // If the difference is more than 30%, the score is zero
    if (percentDifference > maxDifferencePercent)
    {
        return 0;
    }
    

    // Calculate the proportional deduction based on how far off they are
    float deductionRate = maxScore / maxDifferencePercent; // Points deducted per percent difference
    int scoreDeduction = Mathf.RoundToInt(percentDifference * deductionRate);
    
    // Calculate final score
    int finalScore = maxScore - scoreDeduction;
    return finalScore;
}
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
