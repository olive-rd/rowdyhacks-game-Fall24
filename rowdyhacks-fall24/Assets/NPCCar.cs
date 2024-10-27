using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCCar : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;                 // Speed of the NPC car
    public Sprite[] carSprites;              // Array to store car sprites
    private SpriteRenderer spriteRenderer;   // Reference to the SpriteRenderer

    void Start()
    {
        // Get the SpriteRenderer component attached to the NPC car
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Set a random sprite from the carSprites array
        if (carSprites.Length > 0)
        {
            spriteRenderer.sprite = carSprites[Random.Range(0, carSprites.Length)];
        }
    }

    void Update()
    {

        // Move the car left across the screen
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Destroy the NPC if it goes off-screen
        if (transform.position.x < player.transform.position.x-10f) // Adjust based on your screen width
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(!col.gameObject.CompareTag("NPC")){
            Debug.Log("death");
           Death();
        }
    }
    void Death(){
        SceneManager.LoadScene("Game Over");
    }
}

