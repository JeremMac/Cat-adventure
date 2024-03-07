using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
        [SerializeField] private float climbSpeed = 5f;
    private Animator animator;
    private Rigidbody2D body;

    private void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ladder")
        {
            float verticalInput = Input.GetAxis("Vertical");
            body.velocity = new Vector2(body.velocity.x, verticalInput * climbSpeed);
            //transform.Translate(new Vector3(0, verticalInput * climbSpeed * Time.deltaTime, 0));

            // Déclencher l'animation de montée
            if (verticalInput != 0)
            {
                animator.SetBool("Climbing", true);
            }
            else if (verticalInput == 0 && other.tag == "Top") 
            {
                animator.SetBool("Climbing", false);
            }
        }
    }
}
