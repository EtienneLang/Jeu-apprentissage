using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Ennemy : Fighter
{
    private const int MAX_HEALTH = 20;
    private int goldCoins;
    private float timer = 0f;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask playerLayers;
    private float timeAttack = 0;

    public AudioSource attackSound;
    private void Start()
    {
        maxHealth = MAX_HEALTH;
        health = maxHealth;
        HealtBar.SetMaxHealth(maxHealth);
        goldCoins = Random.Range(1,10);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        VerifierAttack();
        
    }
    protected override void Death()
    {
        GameManager.ajouterCoins(goldCoins);
        base.Death();
    }
    private void VerifierAttack()
    {
        int seconds = (int)timer % 60;
       
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        if (hitPlayer.Length > 0 && seconds-timeAttack >= 3)
        {
            Attack(hitPlayer);
        }
        
        
    }
    protected void Attack(Collider2D[] hitPlayer)
    {
        timeAttack = (int)timer % 60;
        foreach (Collider2D player in hitPlayer) 
        {
            if (player.tag == "Player")
            {
                attackSound.Play();
                Damage dmg = new Damage();
                dmg.nbHitPoints = Random.Range(5, 10);
                player.SendMessage("ReceiveDamage", dmg);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); //Pour afficher la sphere d'attaque
    }

}
