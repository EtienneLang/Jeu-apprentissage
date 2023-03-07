using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : Interaclable
{

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
        //Méthode pour aller looter
    }


}
