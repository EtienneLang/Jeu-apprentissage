using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRun : MonoBehaviour
{
    private const float DEFAULT_MOVEMENT = 2f;
    private const float SPRINT_SPEED = 0.5f;
    public float movement_speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isSprinting;
    public float stamina;
    float maxStamina;
    public float sValue;

    public Slider staminaBar;

    private Vector2 movement;

    private void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
    }
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

    /// <summary>
    /// Fonction pour gèrer la stamina, la vitesse et les anniations du joueur
    /// </summary>
    /// <param name="speed">Variable pour gèrer l'animmation, 2=course, 1=marche, 0=idle</param>
    /// <returns></returns>
    private float PlayerSprint(float speed)
    {
        if (Input.GetKey(KeyCode.LeftShift) && staminaBar.value != 0)
        {
            speed = 2;
            DecreaseStamina();
            if (!isSprinting)
            {
                movement_speed += SPRINT_SPEED;
                isSprinting = true;  // Pour éviter d'augmenter la vitesse à l'infini
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) //Quand l'utilisateur lâche shift, on remet la vitesse de base
        {
            movement_speed = DEFAULT_MOVEMENT;
            isSprinting = false;
        }

        if (!isSprinting && stamina < maxStamina)
        {
            IncreaseStamina(); //Si on ne sprint pas et que la stamina n'est pas au maximum, on augmente la stamina
        }

        staminaBar.value = stamina;
        return speed;
    }
    /// <summary>
    /// Fonction qui diminue la stamina selon le temps et une constante
    /// </summary>
    private void DecreaseStamina()
    {
        if (stamina != 0)
        {
            stamina -= sValue * Time.deltaTime;
        }
    }

    /// <summary>
    /// Fonction qui augmente la stamina selon le temps et une constante
    /// </summary>
    private void IncreaseStamina()
    {
        stamina += sValue * Time.deltaTime;
    }
}
