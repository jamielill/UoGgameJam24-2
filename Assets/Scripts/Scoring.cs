using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator
{
    // Method to calculate score based on player's guess and target weight
    public static int CalculateScore(int playerGuess, int targetWeight)
    {
        const int maxScore = 100; // Maximum score a player can achieve
        const float maxPercentageDifferenceAllowed = 30f; // Maximum percentage difference allowed for scoring

        // Calculate the percentage difference between the player's guess and the target weight
        float percentageDifference = Mathf.Abs((playerGuess - targetWeight) / (float)targetWeight * 100);

        // If the percentage difference is more than the maximum allowed, score is 0
        if (percentageDifference > maxPercentageDifferenceAllowed)
        {
            return 0;
        }

        // Calculate the score by subtracting the percentage difference from the maximum score
        int score = maxScore - Mathf.RoundToInt((percentageDifference / maxPercentageDifferenceAllowed) * maxScore);

        return score;
    }
}
