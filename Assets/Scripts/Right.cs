using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{

    public Character_Script player;

    void OnMouseDown()
    {
        // player.SetRight();
        Debug.Log("RIGHT0");
        // player.StartMoving();
        //FindObjectOfType<Character_Script>().SetRight();
        //FindObjectOfType<Character_Script>().StartMoving();
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
