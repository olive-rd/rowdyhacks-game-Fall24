using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Obstacle obstacle;
    public GameObject player;
    public PlayerController playerController;

    public SpriteRenderer spriteRenderer;

    public GameData gameData;

    private void Start()
    {
        StartObstacle();
    }

    void StartObstacle()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = obstacle.normalSprite;

        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();

        gameData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {
            Debug.Log("hit");
            if (gameData.forwardSpeed > 5)
                HitObstacleDeath();
            else
                HitObstacle();
        }
    }
    void HitObstacle()
    {
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
