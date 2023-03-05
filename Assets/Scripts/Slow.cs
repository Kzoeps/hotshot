using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown() {
        FindObjectOfType<Roulette>().SetIsSlowedTrue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
