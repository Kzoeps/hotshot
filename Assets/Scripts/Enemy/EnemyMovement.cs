using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    NavMeshAgent enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.updateRotation = false;
        enemy.updateUpAxis = false;
        player = GameObject.Find("Hero");
        target = GameObject.Find("Hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null) {
            Vector3 playerPosition = player.transform.position;
            enemy.SetDestination(playerPosition);
        }
        // target = player.transform;
    //    enemy.SetDestination(target.position); 
    }
}
