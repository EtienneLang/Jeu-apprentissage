using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : Lootable
{
    public Sprite spriteEmpty;
    public int nbGoldCoins = 20;

    protected override void Loot()
    {
        base.Loot();
        GetComponent<SpriteRenderer>().sprite = spriteEmpty;
        GameManager.ajouterCoins(nbGoldCoins);

        if (Random.Range(1,3) == 1)
        {
            Vector3 position = new Vector3(transform.position.x,transform.position.y - 1.5f, transform.position.z);
            GameManager.SpawnKey(position);
            GameManager.SpawnBaseEnnemy(position);
        }
    }
}
