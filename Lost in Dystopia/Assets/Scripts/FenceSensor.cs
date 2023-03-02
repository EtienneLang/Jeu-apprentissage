using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSensor : Collidable
{

    private bool alreadyTriggered = false;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
        if (!alreadyTriggered)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector3 position = new Vector3(Random.Range(transform.position.x - 3, transform.position.x + 3), Random.Range(transform.position.y - 3, transform.position.y + 3), 0);
                GameManager.SpawnBaseEnnemy(position);
            }
            alreadyTriggered = true;
        }
    }

}
