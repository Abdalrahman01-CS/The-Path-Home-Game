using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnenemy : MonoBehaviour
{
     public GameObject enemyPrefab;  // enemy prefab
    public Transform spawnPoint;

    private bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RespawnPlayer(){
        Instantiate(enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            hasSpawned = true; // prevent multiple spawns
        }
    }
}
