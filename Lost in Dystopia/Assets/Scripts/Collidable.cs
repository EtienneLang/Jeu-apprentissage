using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour
{
    public ContactFilter2D contact;
    protected BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[5];

    protected virtual void Start() 
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void Update() 
    {
        boxCollider.OverlapCollider(contact, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
            {
                OnCollide(hits[i]);
            }
            hits[i] = null;
        }
    }

    protected virtual void OnCollide(Collider2D coll)
    {
        //Pour les enfants
    }
}
