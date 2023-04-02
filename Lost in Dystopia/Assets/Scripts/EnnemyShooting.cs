using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject target;
    public GameObject self;
    private Vector3 aimDirection;
    private float timer;
    private Transform aimTransform;
    private bool canShoot = true;
    private bool seen = false;
    private double modele = 0;
    // Start is called before the first frame update
    void Start()
    {
        aimTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, self.transform.position);
        if (distance >= 4f)
        {
            seen = true;
        }
        if (seen) 
        {
            aimDirection = (target.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            Vector3 aimLocalScale = Vector3.one;
            Vector3 playerLocalScale = new Vector3(3, 3, 3);
            if (angle > 90 || angle < -90)
            {
                aimLocalScale.x = +0.5f;
                aimLocalScale.y = -0.5f;
                playerLocalScale.x = +3f;
            }
            else
            {
                aimLocalScale.x = -0.5f;
                aimLocalScale.y = +0.5f;
                playerLocalScale.x = -3f;
            }
            aimTransform.localScale = aimLocalScale;
            self.transform.localScale = playerLocalScale;

            aimTransform.eulerAngles = new Vector3(0, 0, angle);
            timer += Time.deltaTime;

            if (timer > 2)
            {
                if (canShoot)
                {
                    InvokeRepeating("Shoot", 1f, 0.2f);
                    canShoot = false;
                }
                else if (!canShoot && timer > 4)
                {
                    canShoot = true;
                    timer = 0;
                    CancelInvoke();
                }

            }
        }
        
    }

    void Shoot()
    {
        aimDirection = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle + UnityEngine.Random.Range(0, 30));
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
