// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Character_Script : MonoBehaviour
// {
//     public float speed = 5f; // The speed at which the square moves.
//     public float moveSpeed;
//     public GameObject roulette;
//     private bool isMoving = false;
//     private bool isRight = false;
//     private Vector2 input;
//     private Animator animator;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }
    
//     void Update()
//     {
//         if (isMoving) {
//             if (isRight) {
//                 transform.position += Vector3.right * speed * Time.deltaTime;
//                 Debug.Log("RIGHT2");
//             } else {
//                 transform.position += Vector3.left * speed * Time.deltaTime;
//             }
//         }
//         input.x = Input.GetAxisRaw("Horizontal");
//             input.y = Input.GetAxisRaw("Vertical");
//             if (input != Vector2.zero) {
//                 animator.SetFloat("moveX", input.x);
//                 animator.SetFloat("moveY", input.y);
//                 var targetPos = transform.position;
//                 targetPos.x += input.x;
//                 targetPos.y += input.y;
//                 StartCoroutine(Move(targetPos));
//             }
//         // if (Input.GetKeyDown(KeyCode.LeftArrow))
//         // {
//         //     transform.position += Vector3.left * speed * Time.deltaTime; // Move the square to the left.
//         // }
        
//         // if (Input.GetKeyDown(KeyCode.RightArrow))
//         // {
//         //     transform.position += Vector3.right * speed * Time.deltaTime; // Move the square to the right.
//         // }
//     }

//     IEnumerator Move(Vector3 targetPos) {
//         isMoving = true;
//         while (targetPos != transform.position) {
//             transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
//             yield return null;
//         }
//         isMoving = false;
//         transform.position = targetPos;
//     }

//     void OnTriggerEnter2D(Collider2D other) {
//         Debug.Log(other.gameObject);
//         if (other.gameObject.CompareTag("TreasureChest")) {
//             roulette.SetActive(true);
//         }
//     }

//     public void SetRight() {
//         isRight = true;
//         Debug.Log("RIGHT1");
//     }
//     public void SetLeft() {
//         isRight = false;
//     }
//     public void StartMoving() {
//         isMoving =true;
//     }
    
//     public void StopMoving() {
//         isMoving = false;
//     }
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Script: MonoBehaviour
{
    public float moveSpeed;
    public bool isMoving;
    private Vector2 input;
    private Animator animator;
    public GameObject roulette;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving) {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input != Vector2.zero) {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }
 void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("TreasureChest")) {
            roulette.SetActive(true);
        }
    }   
    IEnumerator Move(Vector3 targetPos) {
        isMoving = true;
        while (targetPos != transform.position) {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isMoving = false;
        transform.position = targetPos;
    }
}
//hi