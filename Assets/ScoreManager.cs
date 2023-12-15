using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance of the ScoreManager
    private static ScoreManager instance;

    // Current score
    private int currentScore = 0;

    // Public property to access the current score
    public int CurrentScore => currentScore;

    // Ensure that there is only one instance of ScoreManager in the scene
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to increase the score by a specified amount
    public void IncreaseScore(int amount)
    {
        currentScore += amount;
        Debug.Log("Score increased by " + amount + ". New score: " + currentScore);
    }

    // You can add more methods or functionality as needed

    // Example: Reset the score to zero
    public void ResetScore()
    {
        currentScore = 0;
        Debug.Log("Score reset to zero.");
    }

    // Provide a static method to get the instance of ScoreManager
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("ScoreManager instance is null.");
            }
            return instance;
        }
    }
}