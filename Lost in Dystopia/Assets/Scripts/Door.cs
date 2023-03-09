using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaclable
{
    public Sprite opennedDoor;
    public Sprite closedDoor;
    public GameObject toit;
    public CapsuleCollider2D playerEntree;
    public bool toitActive = true;

    bool openned = false;


    protected override void OnInteraction()
    {
        playerEntree.GetComponent<CapsuleCollider2D>();
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
