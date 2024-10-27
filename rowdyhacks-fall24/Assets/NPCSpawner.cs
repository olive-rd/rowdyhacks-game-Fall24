using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject npcCarPrefab;  // Assign the NPC Car prefab in the Inspector
    public float spawnInterval = 2f; // Time between each spawn
    public float minY = -5f, maxY = 5f; // Range of Y positions for spawning

    void Start()
    {
        InvokeRepeating(nameof(SpawnNPC), 1f, spawnInterval);
    }

    void SpawnNPC()
    {
        // Random Y position within range
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(player.transform.position.x + 13f, randomY); // Spawn on the right side

        Instantiate(npcCarPrefab, spawnPosition, Quaternion.identity);
    }
}
