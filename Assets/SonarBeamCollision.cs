using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarBeamCollision : MonoBehaviour
{
    // Detect collisions with the sonar beam
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Destroy the sonar beam if it collides with anything
        Destroy(this.gameObject);
        // Destroy the fish if it collides with the sonar beam
        if (collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
        }
    }
}
