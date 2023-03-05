using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Script : MonoBehaviour
{
    public float speed = 5f; // The speed at which the square moves.
    public GameObject roulette;
    private bool isMoving = false;
    private bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update()
    {
        if (isMoving) {
            if (isRight) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } else {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     transform.position += Vector3.left * speed * Time.deltaTime; // Move the square to the left.
        // }
        
        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     transform.position += Vector3.right * speed * Time.deltaTime; // Move the square to the right.
        // }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("TreasureChest")) {
            roulette.SetActive(true);
        }
    }

    public void SetRight() {
        isRight = true;
    }
    public void SetLeft() {
        isRight = false;
    }
    public void StartMoving() {
        isMoving =true;
    }
    
    public void StopMoving() {
        isMoving = false;
    }
}
