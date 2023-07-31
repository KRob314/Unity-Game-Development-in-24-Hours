using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1.5f;
    public float maxSpawnDelay = 4f;
    public float spawnXLimit = 6f;
    private float elapsedTime = 0;

    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        elapsedTime = elapsedTime + Time.deltaTime;

        if (elapsedTime > 10)
        {
            elapsedTime = 0;
            if(maxSpawnDelay > 1)
            {
                maxSpawnDelay -= .1f;
            }

            if(minSpawnDelay > 1)
            {
                minSpawnDelay -= .01f;
            }
        }
    }

    void Spawn()
    {
        // Create a meteor at a random x position
        float random = Random.Range(-spawnXLimit, spawnXLimit);
        Vector3 spawnPos = transform.position + new Vector3(random, 0f, 0f);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);


        Invoke("Spawn", Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
