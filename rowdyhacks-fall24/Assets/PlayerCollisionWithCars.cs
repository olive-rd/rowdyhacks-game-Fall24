using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            // Load the Game Over scene
            Debug.Log("Game Over! Switching to Game Over scene.");
            SceneManager.LoadScene("GameOver"); // Make sure this matches the name of your Game Over scene
        }
    }
}


