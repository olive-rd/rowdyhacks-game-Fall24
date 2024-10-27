using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] public CarData carData = new CarData();
    public bool spinOut = false;
    public bool boosting = false;
    public Vector2 minBounds = new Vector2(-5f, -5f);
    public Vector2 maxBounds = new Vector2(6.5f, 6.5f);

    //forward speed moved to GameData.cs. To access speed, use gameData.speed :)
    public float verticalSpeed = 7f;// Speed for the player-controlled up/down movement
    public float curSpeed;
    public float maxSpeed;

    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        carData.MaxVelocity = 10f;
        carData.Velocity = 2f;
        carData.Acceleration = 10f;
    }

    void Update()
    {
        curSpeed = carData.Velocity;
        maxSpeed = carData.MaxVelocity;
        if (spinOut == false)
        {
            Vector3 clampedPosition = transform.position;
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);

            //Set the position back to the clamped position
            transform.position = clampedPosition;
        
            // Automatically move forward (rightward in a side-scrolling view)
            carData.Velocity += carData.Acceleration * Time.deltaTime;
            if ((carData.Velocity > carData.MaxVelocity) && !boosting)
            {
                carData.Velocity = carData.MaxVelocity;
            }
            // Automatically move forward (rightward in a side-scrolling view)
            transform.Translate(Vector3.right * carData.Velocity * Time.deltaTime,
                Space.World);

            // Get up/down player input and apply vertical movement
            float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys
            rb.velocity = new Vector2(rb.velocity.x, moveInput * verticalSpeed);
        }
        else
        {
            
        }
        
    }
}
