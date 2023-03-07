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
            Loot();
        }
    }

    protected virtual void Loot()
    {
        //M�thode pour aller looter
    }


}
