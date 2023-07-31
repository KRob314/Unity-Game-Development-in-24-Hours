using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawn : MonoBehaviour
{
    public List<GameObject> powerupPrefabs;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        // Create a meteor at a random x position
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        int randomPrefabIndex = Random.Range(0, powerupPrefabs.Count);

        Instantiate(powerupPrefabs[randomPrefabIndex], spawnPos, Quaternion.identity);

        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
