using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObstacleScritableObject : ScriptableObject
{
    public enum ObstacleType{
        slow,
        spin
    }

    public ObstacleType obstacleType;
    public Sprite normalSprite;
    public Sprite futureSprite;
}
