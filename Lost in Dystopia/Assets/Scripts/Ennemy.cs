using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Fighter
{
    private const int MAX_HEALTH = 10;

    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar.SetMaxHealth(maxHealth);
    }

    protected override void Death()
    {
        GameManager.SpawnMedkit(transform);
        base.Death();
    }

}
