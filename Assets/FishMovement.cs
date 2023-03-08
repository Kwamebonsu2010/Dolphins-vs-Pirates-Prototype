using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{

    public float speed = 2f; // The speed of fish movement
    private float minX, maxX; // The minimum and maximum x-axis values for the fish
    private Rigidbody2D rb; // The Rigidbody2D component of the fish

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera bounds
        Camera mainCamera = Camera.main;
        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        // Calculate the minimum and maximum x-axis values for the fish
        minX = mainCamera.transform.position.x - camWidth;
        maxX = mainCamera.transform.position.x + camWidth;

        // Get the Rigidbody2D component of the fish
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the fish horizontally
        Vector2 velocity = rb.velocity;
        velocity.x = speed;
        rb.velocity = velocity;

        // If the fish collides with an obstacle, reverse its direction
        if (rb.IsTouchingLayers())
        {
            speed = -speed;
        }
        // If the fish goes beyond the maximum x-axis value, reverse its direction
        else if (transform.position.x > maxX)
        {
            speed = -speed;
        }
        // If the fish goes beyond the minimum x-axis value, reverse its direction
        else if (transform.position.x < minX)
        {
            speed = Mathf.Abs(speed);
        }
    }

    // Called when the fish collides with another collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reverse the fish direction if it collides with an obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            speed = -speed;
        }
    }
}
