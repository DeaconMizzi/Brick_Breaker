using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    public int scoreValue = 10; // Score value of the brick

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Destroy the brick
            Destroy(gameObject);

            // Update the player's score
            ScoreManager.Instance.AddScore(scoreValue);
        }
    }
}
