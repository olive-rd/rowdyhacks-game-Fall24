using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;        // List of prefabs to spawn
    [SerializeField] public float spawnInterval = 0.3f;      // Time interval between spawns
    public Vector2 ySpawnRange = new Vector2(-5f, 6.5f); // Y range for random position

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval; // Initialize spawn timer
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        // Check if it's time to spawn
        if (spawnTimer <= 0)
        {
            SpawnRandomPrefab();
            spawnTimer = spawnInterval; // Reset the timer
        }
    }

    private void SpawnRandomPrefab()
    {
        // Select a random prefab from the list
        int randomIndex = Random.Range(0, prefabs.Count);
        GameObject prefabToSpawn = prefabs[randomIndex];

        // Determine a random y position within the specified range
        float randomY = Random.Range(ySpawnRange.x, ySpawnRange.y);

        // Spawn the prefab at the current x position and random y position
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, -1);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
