using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interaclable
{
    public Sprite opennedDoor;
    public Sprite closedDoor;
    public GameObject toit;
    public bool toitActive = true;

    bool openned = false;


    protected override void OnInteraction()
    {
        Debug.Log("Door should open");
        if (!openned)
        {
            Debug.Log("Porte ouverte");
            GetComponent<SpriteRenderer>().sprite = opennedDoor;
            GameManager.instance.HideText();
            GameManager.instance.ShowStillText("Press space to close", 25, Color.white, GameManager.instance.player.transform.position);
            boxCollider.enabled = false;
            openned = true;
           
        }
        else
        {
            Debug.Log("Porte fermée");
            GetComponent<SpriteRenderer>().sprite = closedDoor;
            GameManager.instance.HideText();
            GameManager.instance.ShowStillText("Press space to open", 25, Color.white, GameManager.instance.player.transform.position);
            boxCollider.enabled = true;
            openned = false;
        }
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInRange = true;
            if (openned)
            {
                GameManager.instance.ShowStillText("Press space to close", 25, Color.white, GameManager.instance.player.transform.position);
            }
            else
            {
                GameManager.instance.ShowStillText("Press space to open", 25, Color.white, GameManager.instance.player.transform.position);
            }
        }

    }

    protected new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            GameManager.instance.HideText();
    }
}
