using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 using UnityEngine;

public class CyrusMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Set Speed for animation (use square magnitude for smoother transition)
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        // Flip sprite based on direction
if (movement.x != 0)
{
    Vector3 scale = transform.localScale;
    scale.x = -Mathf.Sign(movement.x); // flips based on direction
    transform.localScale = scale;
}

    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
 
