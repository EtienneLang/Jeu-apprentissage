using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaclable
{
    public Sprite opennedDoor;
    public Sprite closedDoor;
    public BoxCollider2D bc;
    bool openned = false;


    protected override void OnInteraction()
    {
        if (!openned)
        {
            Debug.Log("Porte ouverte");
            GetComponent<SpriteRenderer>().sprite = opennedDoor;
            bc.isTrigger = true;
            openned = true;
        }
        else
        {
            Debug.Log("Porte fermée");
            GetComponent<SpriteRenderer>().sprite = closedDoor;
            bc.isTrigger = false;
            openned = false;
        }
        
    }
}
