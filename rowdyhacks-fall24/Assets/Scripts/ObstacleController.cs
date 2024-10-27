using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Object obstacle;

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
    {/*
        switch (obstacle.type)
        {
            case ObstacleType.Slow:
                break;
            case ObstacleType.Spin:
                break;
        }*/
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
