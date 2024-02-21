using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public int rows = 5;
    public int columns = 5;
    public float brickWidth = 1f;
    public float brickHeight = 0.5f;
    public float spacingX = 0.1f; // Spacing between bricks in the X direction
    public float spacingY = 0.1f; // Spacing between bricks in the Y direction
    public Vector2 offset = new Vector2(0.5f, 0.5f); // Offset for positioning bricks

    void Start()
    {
        SpawnBricks();
    }

    void SpawnBricks()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector2 spawnPosition = CalculateSpawnPosition(row, col);
                Instantiate(brickPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

    Vector2 CalculateSpawnPosition(int row, int col)
    {
        // Calculate the total width of a row of bricks
        float totalRowWidth = columns * (brickWidth + spacingX) - spacingX;
        // Calculate the total height of a column of bricks
        float totalColumnHeight = rows * (brickHeight + spacingY) - spacingY;

        // Calculate the starting position of the bottom-left brick
        float startX = transform.position.x - totalRowWidth / 2f + brickWidth / 2f;
        float startY = transform.position.y + totalColumnHeight / 2f - brickHeight / 2f;

        // Calculate the position of the current brick
        float x = startX + col * (brickWidth + spacingX);
        float y = startY - row * (brickHeight + spacingY);

        return new Vector2(x, y);
    }
}