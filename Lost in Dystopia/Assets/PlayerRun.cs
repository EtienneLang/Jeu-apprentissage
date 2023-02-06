using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public float movement_speed = 1f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    void Update()
    {
        float speed = 0;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            speed = 1;
        }
        animator.SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
    }
}
