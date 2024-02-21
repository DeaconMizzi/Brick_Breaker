using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   public static ScoreManager Instance { get; private set; }

    public TMP_Text scoreText; // Reference to the UI text component displaying the score
    private int score = 0; // Current player score

    void Awake()
    {
        // Singleton pattern to ensure only one instance of the ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // Update the UI text component with the current score
        scoreText.text = "Score: " + score.ToString();
    }
}
