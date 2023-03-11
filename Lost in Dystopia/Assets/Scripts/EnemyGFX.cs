using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;
    public Animator animator;
    private Vector3 PrevPos;
    private Vector3 NewPos;
    private Vector3 ObjVelocity;
    // Update is called once per frame
    public void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }
    void FixedUpdate()
    {
        NewPos = transform.position;
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // Pour avoir la vélocité de l'objet
        PrevPos = NewPos; 

        CheckSpeed();
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    public void CheckSpeed()
    {
        bool move = false;
        
        
        if (ObjVelocity != Vector3.zero)
        {
            move = true;
        }
        else
        {
            move = false;
        }
        animator.SetBool("Move", move);
    }
}
