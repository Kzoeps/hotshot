using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public string direction = "right";
    AudioSource explodeSound;
    public GameObject impact;
    private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
       explodeSound = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(impact, transform.position, transform.rotation);
        explodeSound.PlayOneShot(explodeSound.clip, 0.5f);
        Destroy(gameObject);
    }

    void Move(){
        if (direction == "right") {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        } else if (direction == "left") {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        } else if (direction == "up") {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        } else if (direction == "down") {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        } else {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }
}

