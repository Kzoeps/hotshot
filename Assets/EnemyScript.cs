using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : Damage 
{
    AudioSource hurtSound;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public AIPath aiPath;
    public Animator animator;
    public LayerMask playerLayers;
    public AudioSource DyingSound;
    private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        hurtSound = GetComponent<AudioSource>();
        InvokeRepeating("Attack", 2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
       HandleMove(); 
    }

    private void Attack() {
        animator.SetTrigger("Attack");
        if (isInRange) {
            GameObject player = GameObject.Find("Hero");
            player.gameObject.SendMessage("HandleDamage", 10);
        }
        // Collider2D hitHero = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayers);
        // if(hitHero) {
            // Debug.Log(hitHero+"THis IS HITO hEOBj");
            // hitHero.gameObject.SendMessage("HandleDamage", 10);
        // }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter2D");
        if (other.gameObject.CompareTag("Player")) {
            isInRange = true;
            Debug.Log("Player is in range");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            isInRange = false;
            Debug.Log("Player is out of range");
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
        hurtSound.PlayOneShot(hurtSound.clip, 0.5f);
        TakeDamage(20);
    }

    public override void Die() {
        animator.SetBool("IsDead", true);
        DyingSound.PlayOneShot(DyingSound.clip, 0.5f);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.enabled = false;
        Destroy(gameObject, 0.5f);
    }
}
