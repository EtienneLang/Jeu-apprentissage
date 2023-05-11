using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public int nbAmmo;
    public int maxAmmo;
    private float reloadTime;
    private bool isReloading;
    private BulletCountUI TxtBullet;
    private float movement_speed = 1f;
    public Rigidbody2D rb;

    public AudioSource gunSound;
    private bool firingMode;
    Vector2 movement;

    public bool Envent { get; private set; }

    private void Start()
    {
        Debug.Log("playerLoad");
        firingMode = Input.GetMouseButtonDown(0);
        player = GameObject.Find("Player");
        TxtBullet = GameObject.FindGameObjectWithTag("BulletUI").GetComponent<BulletCountUI>();
        aimTransform = null;
        aimAnimator = null;
        aimGunEndPointTransform = null;
        bulletTransform = aimGunEndPointTransform;
        isReloading = false;
    }
    // Update is called once per frame
    void Update()
    {
        HandleAiming();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.R) && nbAmmo < maxAmmo)
        {
            Reload();
        }
    }

    private void Reload()
    {
        if (isReloading)
            return;
        if (nbAmmo == maxAmmo)
            return;        
        isReloading = true;
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        nbAmmo = maxAmmo;
        TxtBullet.UpdateNbAmmo(nbAmmo);
        isReloading = false;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movement_speed * Time.fixedDeltaTime);
    }
    private void HandleShooting()
    {
        if (isReloading)
            return;
        if (nbAmmo == 0)
            Reload();
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
        if (aimTransform == transform.Find("Glock_Prefab")) 
        {
            firingMode = Input.GetMouseButtonDown(0);
        }
        else if (aimTransform == transform.Find("AK_Prefab"))
        {
            firingMode = Input.GetMouseButton(0);
        }
        if (firingMode && canFire)
        {
            if (EventSystem.current.IsPointerOverGameObject()) //Pour ne pas tirer quand curseur sur UI
                return;
            nbAmmo--;
            TxtBullet.UpdateNbAmmo(nbAmmo);
            canFire = false;
            gunSound.pitch = UnityEngine.Random.Range(1.5f, 2.2f);
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

    public void ChangeGun(string gun)
    {
        if (gun == "")
        {
            //Pour qu'on ne puisse pas tiré sans arme
            timeBetweenFiring = 100000000000;
            maxAmmo = 0;
            nbAmmo = maxAmmo;
            TxtBullet.ChangeGun(maxAmmo);
            Debug.Log("CHangé a Rien");
        }
        else if (gun == "AK")
        {
            aimTransform = transform.Find("AK_Prefab");
            aimAnimator = aimTransform.GetComponent<Animator>();
            aimGunEndPointTransform = aimTransform.Find("GunEndPointPositionAK");
            bulletTransform = aimGunEndPointTransform;
            timeBetweenFiring = 0.1f;
            maxAmmo = 40;
            nbAmmo = maxAmmo;
            TxtBullet.ChangeGun(maxAmmo);
            reloadTime = 3f;
            Debug.Log("CHangé a AK");
        }
        else if (gun == "Glock")
        {
            aimTransform = transform.Find("Glock_Prefab");
            aimAnimator = aimTransform.GetComponent<Animator>();
            aimGunEndPointTransform = aimTransform.Find("GunEndPointPositionGlock");
            bulletTransform = aimGunEndPointTransform;
            timeBetweenFiring = 0.5f;
            maxAmmo = 15;
            nbAmmo = maxAmmo;
            TxtBullet.ChangeGun(maxAmmo);
            reloadTime = 2f;
            Debug.Log("CHangé a Glock");
        }
            
    }

}
