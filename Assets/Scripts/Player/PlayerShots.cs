using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShots : MonoBehaviour
{
    AudioSource laserSound;
    public GameObject bulletPrefab;
    public GameObject player;
    public string direction = "right";
    // Start is called before the first frame update
    void Start()
    {
        laserSound = GetComponent<AudioSource>();    
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

    public void Shoot() {
        // add constant since the bullet appears below and behind character
        float offset = 1f;
        if (direction == "right") {
            offset = 1f;
        } else if (direction == "left") {
            offset = -1f;
        } 
        Vector2 bulletPos = new Vector2(player.transform.position.x + offset, player.transform.position.y);
        GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);
        BulletMovement bulletMvmt = bullet.GetComponent<BulletMovement>();
        if (direction != "none") {
            bulletMvmt.direction = direction;
        }
        laserSound.PlayOneShot(laserSound.clip, 0.5f);
    }
}
