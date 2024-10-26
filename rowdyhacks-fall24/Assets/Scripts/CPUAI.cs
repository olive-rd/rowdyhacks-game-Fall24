using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUAI : MonoBehaviour
{
    public CarData carData;
    private Transform playerCarTransform;
    [SerializeField] private bool matchedPlayerVelocity = false;
    //when matching the player's x transformation value, stop the maxSpeed increase
    private bool oneTimeNegative = false;

    void Start()
    {
        {
            // Find the player car GameObject by tag
            GameObject playerCarGameObject = GameObject.FindGameObjectWithTag("Player");
            if (playerCarGameObject != null)
            {
                playerCarTransform = playerCarGameObject.transform;
                var playerCar = playerCarGameObject.GetComponent<CarMovement>();

                // Match the AI car's velocity with the player's velocity at spawn
                if (playerCar.carData.Velocity > playerCar.carData.MaxVelocity)
                {
                    carData.Velocity = playerCar.carData.MaxVelocity;
                }
                else
                {
                    carData.Velocity = playerCar.carData.Velocity;
                }

                // Ensure AI car always has a higher max velocity than the player
                carData.MaxVelocity = playerCar.carData.MaxVelocity + 5.0f;
            }
            else
            {
                Debug.LogError("Player car not found!");
            }
        }
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - playerCarTransform.position.x) >= 15)
        {
            Destroy(gameObject);
            return;
        }
        if (!matchedPlayerVelocity)
        {
            if (transform.position.x < playerCarTransform.position.x)
            {
                carData.Velocity += carData.Acceleration * Time.deltaTime;
                if (carData.Velocity > carData.MaxVelocity)
                {
                    carData.Velocity = carData.MaxVelocity;
                }
            }
            else
            {
                matchedPlayerVelocity = true;
                carData.Velocity = playerCarTransform.GetComponent<CarMovement>().carData.Velocity;
            }
        }
        else
        {
            if (oneTimeNegative == false)
            {
                carData.MaxVelocity-=5;
                oneTimeNegative = true;
            }
            
            if (carData.Velocity <= carData.MaxVelocity)
            {
                carData.Velocity = playerCarTransform.GetComponent<CarMovement>().carData.Velocity;
            }
            
        }

        transform.Translate(0, -(carData.Velocity * Time.deltaTime), 0);
    }
}
