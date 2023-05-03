using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : Damage 
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public AIPath aiPath;
    public Animator animator;
    public LayerMask playerLayers;
    AudioSource youchSound;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
       HandleMove(); 
    }

    private void Attack() {
        animator.SetTrigger("Attack");
        Collider2D hitHero = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);
        if(hitHero) {
            hitHero.gameObject.SendMessage("TakeDamage", 10);
        }
    }

    private void HandleMove() {
        if (aiPath.desiredVelocity.x >= 0.01f) {
            transform.localScale = new Vector3(-1f,1f, 1f);
            animator.SetInteger("AnimState", 2); 
        } else if (aiPath.desiredVelocity.x <= -0.01f) {
            transform.localScale = new Vector3(1f,1f, 1f);
            animator.SetInteger("AnimState", 2); 
        }
    }

    private void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }

    public void HandleDamage() {
        animator.SetTrigger("Hurt");
        youchSound.PlayOneShot(youchSound.clip, 0.5f);
        TakeDamage(20);
    }

    public override void Die() {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
        Destroy(gameObject, 2f);
    }
}
