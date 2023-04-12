using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public GameObject square; // The square object to move.
    
    void OnMouseDown()
    {
        // FindObjectOfType<Character_Script>().SetLeft();
        // FindObjectOfType<Character_Script>().StartMoving();
    }

    private void OnMouseUp() {
        // FindObjectOfType<Character_Script>().StopMoving();    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
