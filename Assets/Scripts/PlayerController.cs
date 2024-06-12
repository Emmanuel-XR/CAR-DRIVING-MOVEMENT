using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;

    private GameObject focalPoint;
    public bool hasPowerUp = false;

    private float powerUpStrength = 15.0f;
    private float powerUpTimer = 7.0f;
    public GameObject powerUpIndicator;

    // PowerUp Indicator offset from the ground
    private Vector3 offset = new Vector3(0, -0.5f, 0);


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find ("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        
        // Camera movement
        playerRb.AddForce (focalPoint.transform.forward * speed * forwardInput);
        
        // Moving the powerUp inidcator with the player object
        powerUpIndicator.transform.position = transform.position + offset;
    }


    private void OnTriggerEnter(Collider other)
    {
        // On Player Collision with Other object, DO the following
        if (other.CompareTag ("PowerUp"))
        {
            // Detecting the powerUp condition
            hasPowerUp = true;
            Destroy (other.gameObject);
            
            // Starting the countdown timer
            StartCoroutine(PowerUpCountdownRoutine());
            
            // Displaying the powerUp indicator
            powerUpIndicator.SetActive (true);
        }
    }


    // Countdown timer for powerUp Indicator
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds (powerUpTimer);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }

    // On Collision with
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        { 
            // Getting and storing the information of the collided object
            Rigidbody EnemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            
            // Setting the new position of the collided object
            Vector3 awayFromPlayer = EnemyRigidbody .transform.position - transform.position;

            // Momentum of the object after collision
            EnemyRigidbody.AddForce (awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
            // Debug message for the collision
            Debug.Log ("Collided with" + collision.gameObject.name + "and powerUp condition is" + hasPowerUp);
        }
    }
}
