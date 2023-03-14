using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : Interaclable
{
    private bool isLooted = false;

    protected override void OnInteraction()
    {
        if (!isLooted)
        {
            isLooted = true;
            GameManager.instance.HideText();
            Loot();
        }
    }

    protected virtual void Loot()
    {
        //Méthode pour aller looter
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isLooted && collision.tag == "Player")
        {
            isInRange = true;
            GameManager.instance.ShowStillText("Press space to loot", 25, Color.white, GameManager.instance.player.transform.position);
        }
    }

    protected new void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        GameManager.instance.HideText();
    }

}
