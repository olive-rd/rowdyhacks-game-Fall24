using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public CarData carData;

    void Update()
    {
        if (carData.Velocity < carData.MaxVelocity)
        {
            carData.Velocity += carData.Acceleration * Time.deltaTime;
            if (carData.Velocity > carData.MaxVelocity)
            {
                carData.Velocity = carData.MaxVelocity;
            }
        }

        transform.Translate(0, -(carData.Velocity * Time.deltaTime), 0); // Move on the x-axis
    }
}
