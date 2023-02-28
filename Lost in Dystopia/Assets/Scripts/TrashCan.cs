using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : Collectable
{
    public int nbGoldCoins = 10;
    public Sprite emptyTrashcan;

    protected override void OnCollect()
    {
        GetComponent<SpriteRenderer>().sprite = emptyTrashcan;
    }


}
