using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Reference to the car (target to follow)
    public Vector3 offset;          // Offset position of the camera relative to the car
    public float smoothSpeed = 0.125f;  // Smooth transition speed

    void LateUpdate()
    {
        if (target != null)
        {
            // Only follow the X position of the car, keeping Y and Z fixed
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, offset.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


