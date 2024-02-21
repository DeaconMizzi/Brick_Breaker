using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 5f;
    private float paddleHalfWidth;
    // Start is called before the first frame update
    void Start()
    {
        paddleHalfWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
       // Get input for paddle movement
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate paddle's target position based on input
        Vector3 targetPosition = transform.position + Vector3.right * moveInput * paddleSpeed * Time.deltaTime;

        // Clamp the paddle's target position to stay within screen bounds
        float clampedX = Mathf.Clamp(targetPosition.x, GetScreenLeftBound() + paddleHalfWidth, GetScreenRightBound() - paddleHalfWidth);
        targetPosition.x = clampedX;

        // Apply the clamped position to the paddle
        transform.position = targetPosition;
    }
    float GetScreenLeftBound()
    {
        return Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }

    // Helper function to get the right bound of the screen
    float GetScreenRightBound()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
    }
}
