using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject cloudPrefab;
    private GameObject cloud;
    public int number = 10;
    public float spawnRadius = 10f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i< number;i++){
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.transform.parent = transform;

            GameObject cloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            cloud.transform.parent = transform;

            //cloud.gameObject.active = true;
            // To move it to a distance of 0.5f up
            //   cloud.transform.position = new Vector3(cloud.transform.position.x, Mathf.Lerp(cloud.transform.position.y, cloud.transform.position.y+0.5f,2f),cloud.transform.position.z); 

            ////for disappearing your cloud in your disappear condition write

            //   cloud.gameObject.renderer.material.color.a = Mathf.Lerp(1f,0f,2f);
        }
    }

    // Update is called once per frame

    void Update()
    {

        while (timer < 0.5)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 0.5)
        {
            Destroy(cloud);
            Debug.Log("cloud destroyed");
        }
    }
}
