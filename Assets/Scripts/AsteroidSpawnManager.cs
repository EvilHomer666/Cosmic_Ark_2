using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawnManager : MonoBehaviour
{
    // Right side spawn location
    private float spawnPosX = 125f;
    private float spawnRangeY = 85f;
    private float spawnPosZ = 0.0f;


    public float spawnInterval = 1.25f;
    public float startDelay;

    // Spawn manager array for enemy prefabs
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // Custom functions to spawn random enemies
    void SpawnRandomEnemy()
    {
        // Randomly generate enemies per screen location
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}

