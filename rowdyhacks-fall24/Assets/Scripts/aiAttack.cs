using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiAttack : MonoBehaviour
{
    
    private Rigidbody2D parentRigidbody;

    void Start()
    {
        // Get the Rigidbody2D of the parent AI car
        parentRigidbody = GetComponentInParent<Rigidbody2D>();
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

            // Disable AI movement after colliding with the player
            parentRigidbody.velocity = Vector2.zero;
        }
    }


}
