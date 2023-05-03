using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Damage 
{
    public float moveSpeed;
    public bool isMoving;
    AudioSource owwSound;
    public AudioSource DyingSound;
    public GameObject playerShots;
    public Joystick joystick;
    public Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;
    string currentDirection = "right";
    Vector2 movement; 

    // float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        owwSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if (GetIsMoving()) {
            animator.SetBool("isMoving", true);
            SetMotion();
            if (GetHeaviestDirection() != "none") {
                SetPlayerShots(GetHeaviestDirection());
                currentDirection = GetHeaviestDirection();
            }
        } else {
            animator.SetBool("isMoving", false);
        }
        
    }

    void HandleDamage(int amount) {
        owwSound.Play(1);
        if (currentDirection == "left" || currentDirection == "up" || currentDirection == "down") {
            animator.SetFloat("moveX", 0);
        } else {
            animator.SetFloat("moveX", 1);
        }
        animator.SetTrigger("IsHurt");
        TakeDamage(amount);
    }

    public override void Die() {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        DyingSound.PlayOneShot(DyingSound.clip, 0.5f);
        Destroy(gameObject, 1f);
    }


    void SetPlayerShots(string direction) {
        playerShots.GetComponent<PlayerShots>().direction = direction;
    }
// Because joystick motion ranges from -1 to 1 and is not discrete we need to get whichever direction is moving in the most
    void SetMotion() {
        // write a switch case which calls GetHeaviesDirection and sets the animator to the correct direction
        switch (GetHeaviestDirection()) {
            case "up":
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 1);
                break;
            case "down":
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", -1);
                break;
            case "left":
                animator.SetFloat("moveX", -1);
                animator.SetFloat("moveY", 0);
                break;
            case "right":
                animator.SetFloat("moveX", 1);
                animator.SetFloat("moveY", 0);
                break;
            default:  
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 0);
                break;
        }
    }

    public string GetHeaviestDirection() {
        if (movement.y >= 0.5f) {
            return "up";
        } else if (movement.y <= -0.5f) {
            return "down";
        } else if (movement.x >= 0.5f) {
            return "right";
        } else if (movement.x <= -0.5f) {
            return "left";
        } else {
            return "none";
        }
    }

    bool GetIsMoving() {
        return (movement.y >= 0.5f || movement.y <= -0.5f || movement.x >= 0.5f || movement.x <=-0.5f); 
    }

    void FixedUpdate() {
        if (GetIsMoving()) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);        
        }
    }
    
    
    
}

// UNNNEEDED CODE

// animator.SetFloat("moveX", movement.x);
        // animator.SetFloat("moveY", movement.y);
        // if (!isMoving) {
            
        //     input.x = Input.GetAxisRaw("Horizontal");
        //     input.y = Input.GetAxisRaw("Vertical");
        //     Debug.Log("input: " + input.x);
        //     if (input != Vector2.zero) {
        //         animator.SetFloat("moveX", input.x);
        //         animator.SetFloat("moveY", input.y);
        //         var targetPos = transform.position;
        //         targetPos.x += input.x;
        //         targetPos.y += input.y;
        //         StartCoroutine(Move(targetPos));
        //     }
        // }
// IEnumerator Move(Vector3 targetPos) {
//         isMoving = true;
//         while (targetPos != transform.position) {
//             transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
//             yield return null;
//         }
//         isMoving = false;
//         transform.position = targetPos;
//     }