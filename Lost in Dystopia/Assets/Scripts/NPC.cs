using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody2D rb;
    public AIPath aiPath;
    public Animator animator;
    private Vector3 PrevPos;
    private Vector3 NewPos;
    private Vector3 ObjVelocity;
    // Start is called before the first frame update
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
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(3f, 3f, 1f);
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
