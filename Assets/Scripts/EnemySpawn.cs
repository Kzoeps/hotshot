using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int number = 10;
    public float spawnRadius = 10f;


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i< number;i++){
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
