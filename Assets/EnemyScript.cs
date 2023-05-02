using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int health = 100;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount) {
        health -= amount;
        animator.SetTrigger("Hurt");
        if (health <= 0) {
            Die();
        }
    }

    public void Die() {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
        Destroy(gameObject, 2f);
    }
}
