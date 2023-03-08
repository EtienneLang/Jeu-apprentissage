using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaclable
{
    public Sprite opennedDoor;
    public Sprite closedDoor;
    bool openned = false;


    protected override void OnInteraction()
    {
        Debug.Log("Door should open");
        if (!openned)
        {
            Debug.Log("Porte ouverte");
            GetComponent<SpriteRenderer>().sprite = opennedDoor;
            boxCollider.enabled = false;
            openned = true;
        }
        else
        {
            Debug.Log("Porte fermée");
            GetComponent<SpriteRenderer>().sprite = closedDoor;
            boxCollider.enabled = true;
            openned = false;
        }
        
    }
}
