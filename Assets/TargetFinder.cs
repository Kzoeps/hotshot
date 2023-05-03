using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private Pathfinding.AIDestinationSetter aIDestinationSetter;
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        TargetPlayer();    
    }
    public void TargetPlayer() {
        target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Finding target");
        Debug.Log(target);
        aIDestinationSetter.target = target.transform;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
