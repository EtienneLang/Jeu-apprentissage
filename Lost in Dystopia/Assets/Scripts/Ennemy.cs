using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Fighter
{
    private const int MAX_HEALTH = 10;
    private int goldCoins;

    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar.SetMaxHealth(maxHealth);
        goldCoins = Random.Range(1,10);
    }

    protected override void Death()
    {
        GameManager.SpawnMedkit(transform);
        GameManager.ajouterCoins(goldCoins);
        base.Death();
    }

}
