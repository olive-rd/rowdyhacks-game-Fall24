using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Obstacle : ScriptableObject
{
    public enum ObstacleType
    {
        slow,
        spin
    }

    public ObstacleType obstacleType;
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite futureSprite;

}