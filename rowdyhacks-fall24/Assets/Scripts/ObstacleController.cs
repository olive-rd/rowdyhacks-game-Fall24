using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle obstacle;

    //--temp variables for testing---
    public int speed = 10;

    //---end temp variables ---

    //public GameData gameData;

    void OnCollisionEnter2D()
    {
        if (speed > 5)
            HitObstacleDeath();
        else
            HitObstacle();

    }
    void HitObstacle()
    {
        switch (obstacle.obstacleType)
        {
            case Obstacle.ObstacleType.Slow:
                break;
            case Obstacle.ObstacleType.Spin:
                break;
        }
    }

    void HitObstacleDeath()
    {
        Debug.Log("Death");
    }

    void Slow()
    {
        Debug.Log("Slowed down");
    }
    void Spin()
    {
        Debug.Log("Spin out");
    }
}
