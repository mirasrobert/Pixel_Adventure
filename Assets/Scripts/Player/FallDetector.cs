using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private Vector3 respawnPoint;
    public GameObject fallDetector = null;

    [SerializeField] public bool hasFallDetector = false;

    // Start is called before the first frame update
    void Start()
    {
        if (hasFallDetector)
        {
            respawnPoint = transform.position;
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (hasFallDetector)
        {
            // Move fall detector when player moves
            fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasFallDetector)
        {
            // If Player or this game object where this script attached to collides with the tag of fall detector
            if (collision.CompareTag("fall_detector"))
            {
                this.GetComponent<Health>().TakeDamage(1); // Take Damage
                this.GetComponent<Health>().ReduceHealthBar(); // Reduce HealthBar on UI

                // Respawn the player
                transform.position = respawnPoint;
            }
        }

    }
}
