using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRainSpawner : MonoBehaviour
{
    public GameObject fireDropletPrefab;

    [Header("Spawn Range")]
    public float leftX = -6f;
    public float rightX = 6f;
    public float spawnY = 6f;

    [Header("Rain Settings")]
    public float spawnInterval = 0.4f; 
    public int dropletsPerSpawn = 4;      // number of droplets each cycle
    public float horizontalSpread = 0.5f; // spacing between droplets

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnDropletBurst();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnDropletBurst()
    {
        for (int i = 0; i < dropletsPerSpawn; i++)
        {
            float x = Random.Range(leftX, rightX);

            // add slight spread so droplets don't overlap
            x += (i - (dropletsPerSpawn - 1) / 2f) * horizontalSpread;

            Vector3 spawnPos = new Vector3(x, spawnY, 0f);

            Instantiate(fireDropletPrefab, spawnPos, Quaternion.identity);
        }
    }
}

