using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartBall();
    }

    void Update()
    {
        // Ensure constant speed by normalizing velocity
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void StartBall()
    {
        // Calculate a random direction for the initial velocity
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        // Launch the ball with the calculated random direction
        rb.velocity = randomDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Bounce off the paddle
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float hitPosition = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(hitPosition, 1).normalized;
            rb.velocity = direction * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If the ball hits the top or sides of the screen, reflect its velocity
        if (other.CompareTag("ScreenBoundary"))
        {
            Vector2 normal = other.transform.up;
            Vector2 reflectDirection = Vector2.Reflect(rb.velocity, normal).normalized;
            rb.velocity = reflectDirection * speed;
        }
        // If the ball falls below the screen, reset it
        else if (other.CompareTag("BottomBoundary"))
        {
            // Reset the ball's position and relaunch
            transform.position = Vector3.zero; // You may adjust this to match your spawn position
            StartBall();
        }
    }
}