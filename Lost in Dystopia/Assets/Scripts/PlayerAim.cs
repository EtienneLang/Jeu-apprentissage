using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAim : MonoBehaviour
{
    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private GameObject player;
    private Animator aimAnimator;


    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    public float movement_speed = 1f;
    public Rigidbody2D rb;

    public AudioSource gunSound;

    Vector2 movement;

    public bool Envent { get; private set; }

    private void Awake()
    {
        player = GameObject.Find("Player");
        //aimTransform = transform.Find("AK_Prefab");
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }
    // Update is called once per frame
    void Update()
    {
        
            HandleAiming();
            
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
    }
    private void HandleShooting()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            if (EventSystem.current.IsPointerOverGameObject()) //Pour ne pas tirer quand curseur sur UI
                return;
            canFire = false;
            gunSound.pitch = Random.Range(1.5f, 2.2f);
            gunSound.Play();
            aimAnimator.SetTrigger("Shoot");
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
    /// <summary>
    /// Fonction permetant au personnage et au fusil de suivre le curseur
    /// </summary>
    private void HandleAiming()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        Vector3 aimLocalScale = Vector3.one;
        Vector3 playerLocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimLocalScale.x = +1f;
            aimLocalScale.y = -1f;
            playerLocalScale.x = +1f;
        }
        else
        {
            aimLocalScale.x = -1f;
            aimLocalScale.y = +1f;
            playerLocalScale.x = -1f;
        }
        if (aimTransform != null)
        {
            aimTransform.localScale = aimLocalScale;
            aimTransform.eulerAngles = new Vector3(0, 0, angle);
            HandleShooting();
        }
        player.transform.localScale = playerLocalScale;
    }
    /// <summary>
    /// Crée un vecteur avec la position de la souris et de la camera
    /// </summary>
    /// <returns>La position de la souris dans un vecteur</returns>
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    /// <summary>
    /// La position d'un vecteur realif a une camera
    /// </summary>
    /// <param name="screenPosition">Une position</param>
    /// <param name="worldCamera">La camera principale</param>
    /// <returns>Un vecteur de position</returns>
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
