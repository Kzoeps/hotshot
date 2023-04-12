using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShots : MonoBehaviour
{
    public GameObject bulletPrefab;
    private string direction = "right";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) {
          SetDirection();
         Shoot();
       } 
    }

    void SetDirection() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            direction = "left";
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            direction = "right";
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            direction = "up";
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            direction = "down";
        }
    }

    void Shoot() {
        // add constant since the bullet appears below and behind character
        Vector2 bulletPos = new Vector2(transform.position.x + 1f, transform.position.y);
        GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);
        BulletMovement bulletMvmt = bullet.GetComponent<BulletMovement>();
        bulletMvmt.direction = direction;
    }
}
