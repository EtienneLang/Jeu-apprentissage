using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaclable : Collidable
{
    private bool isLooted = false;
    private bool isInRange;
    KeyCode lootKey = KeyCode.Space;

    protected override void OnCollide(Collider2D coll)
    {
        if (isInRange && Input.GetKeyDown(lootKey))
        {
            Debug.Log(coll.name);
            if (coll.name == "Player")
            {
                OnInteraction();
                isLooted = true;
                Debug.Log("Looted");

            }
        }
    }

    protected virtual void OnInteraction() 
    {
        //Logique de quoi faire quand on loot un objet (dans les enfants)
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isInRange = true;
            Debug.Log("player in range");
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        //Debug.Log("Player is out of range");
    }

}
