using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CPUAI : MonoBehaviour
{
    public CarData carData;
    private Transform playerCarTransform;
    private bool matchedPlayerVelocity = false;
    private bool coroutineRunning = false;
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
        if (Mathf.Abs(transform.position.x - playerCarTransform.position.x) >= 100)
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

                // Start the coroutine once the AI car is level with the player car
                if (!coroutineRunning)
                {
                    coroutineRunning = true;
                    StartCoroutine(BumperCarBehavior());
                }
            }
        }
        //de-apply the speed boost to catch up to the player
        if (oneTimeNegative == false)
        {
            carData.MaxVelocity-=5;
            oneTimeNegative = true;
        }
            
        if (carData.Velocity <= carData.MaxVelocity)
        {
            carData.Velocity = playerCarTransform.GetComponent<CarMovement>().carData.Velocity;
        }

        transform.Translate(Vector3.right * carData.Velocity * Time.deltaTime, Space.Self); // Move in local space
    }

    private IEnumerator BumperCarBehavior()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 8f));

            // Accelerate towards the player car
            float targetY = Random.Range(-4.5f, 4.5f);
            float direction = targetY > transform.localPosition.y ? 1f : -1f;

            while (Mathf.Abs(transform.localPosition.y - targetY) > 0.1f)
            {
                transform.Translate(Vector3.up * direction * carData.Acceleration * Time.deltaTime, Space.Self);
                yield return null;
            }

            // Move to the opposite range on the y-axis
            targetY = transform.localPosition.y > 0 ? -4.5f : 4.5f;
            direction = targetY > transform.localPosition.y ? 1f : -1f;

            while (Mathf.Abs(transform.localPosition.y - targetY) > 0.1f)
            {
                transform.Translate(Vector3.up * direction * carData.Acceleration * Time.deltaTime, Space.Self);
                yield return null;
            }
        }
    }
}
