using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Collectable
{
    public int nbGoldCoins = 10;
    public Sprite emptyTrashcan;
    public GameObject medkit;

    protected override void OnCollect()
    {
        GetComponent<SpriteRenderer>().sprite = emptyTrashcan;
        GameManager.ajouterCoins(nbGoldCoins);
        GameManager.SpawnMedkit(transform);
    }


}
