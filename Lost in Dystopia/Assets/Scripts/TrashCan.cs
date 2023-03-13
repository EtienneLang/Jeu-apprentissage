using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Lootable
{
    public int nbGoldCoins = 10;
    public Sprite emptyTrashcan;
    public GameObject medkit;


    protected override void Loot()
    {
        GetComponent<SpriteRenderer>().sprite = emptyTrashcan;
        GameManager.ajouterCoins(nbGoldCoins);
        GameManager.SpawnMedkit(transform);
    }


}
