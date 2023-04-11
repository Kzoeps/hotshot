using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShots : MonoBehaviour
{
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) {
         Shoot();
       } 
    }

    void Shoot() {
        // add constant since the bullet appears below and behind character
        Vector2 bulletPos = new Vector2(transform.position.x +11f, transform.position.y + 1.5f);
        GameObject bullet = Instantiate(bulletPrefab, bulletPos, transform.rotation);
    }
}
