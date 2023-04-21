using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter 
{
    private const int MAX_HEALTH = 25;
    public int goldCoins = 0;

    public int GoldCoins { get { return goldCoins; } set {goldCoins=value;} }
    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealtBar>();
        HealtBar.SetMaxHealth(maxHealth);
    }
    public void Heal()
    {
        if (health >=20 || health == 25)
        {
            health = 25;
            Debug.Log("+20");
        }
        else
        {
            Debug.Log("-20");
            health += 5;
        }
        HealtBar.SetHealt(health);
    }
    
}
