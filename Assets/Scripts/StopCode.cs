using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCode : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown() {
        Debug.Log("Stop");
        FindObjectOfType<Roulette>().HandleClick(index);
    }
}
