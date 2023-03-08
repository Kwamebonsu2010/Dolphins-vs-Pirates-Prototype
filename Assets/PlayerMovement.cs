using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float speed = 7f;
    bool goingLeft = false;
    public GameObject SonarBeamPrefab; // The prefab for the sonar beam


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        // Flip the direction (currently rotating 180 degrees instead of flipping)
        if( (dirX < 0 && !goingLeft) || (dirX > 0 && goingLeft) )
        {
            goingLeft = !goingLeft;
            rb.transform.Rotate( new Vector3( 0, 0, 180 ));
        }

        // Update location
        rb.velocity = new Vector2(dirX*speed, dirY*speed);

        // Shoot a sonar beam when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create a sonar beam from the SonarBeamPrefab
            GameObject sonarBeam = Instantiate(SonarBeamPrefab, transform.position, Quaternion.identity);

            // Set the direction of the sonar beam to the right or left based on the direction of the player
            if (goingLeft)
            {
                sonarBeam.transform.Rotate( new Vector3( 0, 0, 180 ) );
                sonarBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0f);
            }
            else
            {
                sonarBeam.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, 0f);
            }
        }
    }
}
