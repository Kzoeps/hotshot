using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackProduction : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 1000000f;
    private float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
       nextSpawnTime = Time.time + spawnInterval; 
       Debug.Log(Time.time + " " + nextSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
       HandleSpawning(); 
    }

    private void HandleSpawning()
    {
        if (Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 5f;
            nextSpawnTime = Time.time + spawnInterval;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
