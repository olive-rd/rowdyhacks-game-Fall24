using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CPUAI : MonoBehaviour
{
    public CarData carData;
    private Transform playerCarTransform;
    [SerializeField] private bool matchedPlayerVelocity = false;
    private bool oneTimeNegative = false;


    void Start()
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

    void Update()
    {
        if (playerCarTransform == null) return;

        // Check if the AI car is 100 units less than or more than the player car's x-position
        if (Mathf.Abs(transform.position.x - playerCarTransform.position.x) >= 25)
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
            //de-apply the speed boost to catch up to the player
            if (oneTimeNegative == false)
            {
                carData.MaxVelocity -= 5;
                oneTimeNegative = true;
            }

            if (carData.Velocity <= carData.MaxVelocity)
            {
                carData.Velocity = playerCarTransform.GetComponent<CarMovement>().carData.Velocity;
            }
        }

        transform.Translate(Vector3.right * carData.Velocity * Time.deltaTime,
            Space.World); // Move in world space along the X axis
    }


}
