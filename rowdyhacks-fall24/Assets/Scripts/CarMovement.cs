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

        transform.Translate(Vector3.right * carData.Velocity * Time.deltaTime, Space.World); // Move in world space along the X axis
    }


}
