using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter 
{
    private const int MAX_HEALTH = 100;
    public int goldCoins = 0;

    public int GoldCoins { get { return goldCoins; } set {goldCoins=value;} }
    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealtBar>();
        HealtBar.SetMaxHealth(maxHealth);
    }
    
}
