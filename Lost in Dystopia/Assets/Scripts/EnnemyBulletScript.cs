using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBulletScript : Collidable
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    public GameObject blood;
    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = GetComponent<BoxCollider2D>();
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    // Update is called once per frame
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Wall")
        {
            Debug.Log("Hit the wall");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Hitbox")
        {
            Debug.Log("hit the player");
            Damage dmg = new Damage();
            dmg.nbHitPoints = 1;
            player.SendMessage("ReceiveDamage", dmg);
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
