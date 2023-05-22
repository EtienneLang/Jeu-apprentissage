using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRun : MonoBehaviour
{
    private const float DEFAULT_MOVEMENT = 2f;
    private const float SPRINT_SPEED = 1f;
    public float movement_speed;
    public Rigidbody2D rb;
    public Animator animator;
    public bool isSprinting;
    public float stamina;
    float maxStamina;
    public float sValue;
    public AudioSource footStepGrass;
    public AudioSource footStepConcrete;
    private Collider2D footCollider;
    private Slider staminaBar;
    private string nameGround;
    private Vector2 movement;
    private float timer;
    private void Start()
    {
        staminaBar = GameObject.FindGameObjectWithTag("StaminaSlider").GetComponent<Slider>();
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
        footCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
        float volume = PlayerPrefs.GetFloat("SoundVolume");
        footStepGrass.volume = volume;
        footStepConcrete.volume = volume;
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
        timer += Time.deltaTime;
        CheckGoundSound();
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
            movement_speed = DEFAULT_MOVEMENT;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == footCollider)
            nameGround = "concrete";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == footCollider) 
            nameGround = "grass";
    }
    private void CheckGoundSound()
    {
        if (movement.x != 0 || movement.y != 0)
        {
            if (nameGround == "grass")
            {
                if (timer > 0.5)
                {
                    footStepGrass.pitch = Random.Range(0.8f, 1.2f);
                    footStepGrass.Play();
                    timer = 0;
                }
                    
                footStepConcrete.Stop();
            }
            else if (nameGround == "concrete")
            {
                if (timer > 0.5)
                {
                    footStepConcrete.pitch = Random.Range(0.8f, 1.2f);
                    footStepConcrete.Play();
                    timer = 0;
                }
                footStepGrass.Stop();
            }
        }
        else
        {
            footStepGrass.Stop();
            footStepConcrete.Stop();
        }


    }
}
