using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;      // Speed at which the car moves automatically from left to right
    public float verticalSpeed = 3f;      // Speed for the player-controlled up/down movement

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Automatically move forward (rightward in a side-scrolling view)
        rb.velocity = new Vector2(forwardSpeed, rb.velocity.y);

        // Get up/down player input and apply vertical movement
        float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys
        rb.velocity = new Vector2(rb.velocity.x, moveInput * verticalSpeed);
    }
}
