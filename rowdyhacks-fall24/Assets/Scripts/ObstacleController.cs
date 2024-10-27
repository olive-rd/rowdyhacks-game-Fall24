using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle obstacle;
    [SerializeField]public GameObject player;
    public PlayerController playerController;

    public SpriteRenderer spriteRenderer;

    public GameData gameData;
    private CarData playerCarData;
    private Movement movement;
    private void Start()
    {
        StartObstacle();
        playerCarData = player.GetComponent<CarData>();
        movement = player.GetComponent<Movement>();
    }
    

    void StartObstacle()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetSprite();
        movement = player.GetComponent<Movement>();
        playerController = player.GetComponent<PlayerController>();
        playerCarData = player.GetComponent<CarData>();
        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
    }

    void SetSprite()
    {
        if(gameData.boostActive)
            spriteRenderer.sprite = obstacle.futureSprite;
        else
            spriteRenderer.sprite = obstacle.normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(("Player")))
        {
            Debug.Log("hit");
            if (movement.curSpeed - (movement.maxSpeed * .7f) <= 0)
            {
                Debug.Log(movement.curSpeed);
                HitObstacleDeath();
            }
            else
            {
                HitObstacle();
            }
            
        }
    }
    void HitObstacle()
    {
        Debug.Log(obstacle.obstacleType);
        switch (obstacle.obstacleType)
        {
            case Obstacle.ObstacleType.Slow:
                playerController.StartSlowed();
                break;
            case Obstacle.ObstacleType.Spin:
                playerController.StartSpin();
                break;
        }
    }

    void HitObstacleDeath()
    {
        Debug.Log("Death");
    }
}
