using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;

    private Vector3 positionAvant;
    // Update is called once per frame
    void Update()
    {
        CheckSpeed();
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        positionAvant = rb.transform.position;
    }

    public void CheckSpeed()
    {
        Vector3 positionApres = rb.transform.position;
        bool move = false;
        
        
        if (positionAvant != positionApres)
        {
            move = true;
        }
        else
        {
            move = false;
        }
        Debug.Log($"{move}");


    }
}
