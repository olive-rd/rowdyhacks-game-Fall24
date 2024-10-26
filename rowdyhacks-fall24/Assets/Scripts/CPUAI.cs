using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUAI : MonoBehaviour
{
    public CarData carData;
    public Transform playerCarTransform;
    [SerializeField] private bool matchedPlayerVelocity = false;

    void Start()
    {
        // Ensure AI car always has a higher max velocity than the player
        carData.MaxVelocity = playerCarTransform.GetComponent<CarMovement>().carData.MaxVelocity + 5.0f;
    }

    void Update()
    {
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
            carData.Velocity = playerCarTransform.GetComponent<CarMovement>().carData.Velocity;
        }

        transform.Translate(0, -(carData.Velocity * Time.deltaTime), 0);
    }
}
