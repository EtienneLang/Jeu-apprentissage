using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Fighter 
{
    private const int MAX_HEALTH = 25;
    public int goldCoins = 0;
    public Inventory inventaire;

    public int GoldCoins { get { return goldCoins; } set {goldCoins=value;} }
    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealtBar>();
        HealtBar.SetMaxHealth(maxHealth);
        inventaire = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
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


    protected override void Death()
    {
        foreach (GameObject slot in inventaire.slots)
        {
            foreach (Transform child in slot.transform)
                Destroy(child.gameObject);
        }
        inventaire.items.Clear();
        SceneManager.LoadScene(2);
    }

}
