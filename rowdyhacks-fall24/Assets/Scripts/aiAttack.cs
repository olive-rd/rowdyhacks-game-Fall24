using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiAttack : MonoBehaviour
{
    
    private Rigidbody2D parentRigidbody;
    private CPUAI aiCarScript;

    void Start()
    {
        // Get the Rigidbody2D of the parent AI car
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
        aiCarScript = GetComponentInParent<CPUAI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calculate repulse direction based on collision contact normal
            Vector2 repulseDirection = collision.contacts[0].normal;

            // Apply repulse force to both the AI car and the Player car
            parentRigidbody.AddForce(repulseDirection * parentRigidbody.velocity.magnitude, ForceMode2D.Impulse);
            collision.rigidbody.AddForce(-repulseDirection * collision.rigidbody.velocity.magnitude, ForceMode2D.Impulse);

            // Stop and restart the bumper car coroutine
            aiCarScript.RestartBumperCarCoroutine();
        }
    }
}
