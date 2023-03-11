using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    private const float DEFAULT_MOVEMENT = 2f;
    private const float SPRINT_SPEED = 0.5f;
    public float movement_speed;
    public bool sprint = false;
    public Rigidbody2D rb;
    public Animator animator;
    private bool isSprinting;

    private Vector2 movement;
    void Update()
    {
        float speed = 0;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0 || movement.y != 0)
        {
            speed = 1;
        }
        speed = PlayerSprint(speed);

        animator.SetFloat("Speed", speed);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
    }
    private float PlayerSprint(float speed)
    {
        
        if (Input.GetKey(KeyCode.LeftShift)) // while player holds shift he can sprint
        {
            speed = 2;
            if (!isSprinting)
            {
                movement_speed += SPRINT_SPEED;
                isSprinting = true; // right after we apply the double speed or whatever, we set the bool to true so it can't do it over and over again.
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // as soon as he lets go, the bool turns false and the speed is reset
        {
            movement_speed = DEFAULT_MOVEMENT;
            isSprinting = false;
        }
        return speed;
    }
}
