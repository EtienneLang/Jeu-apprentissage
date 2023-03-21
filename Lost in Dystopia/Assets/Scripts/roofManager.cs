using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofManager : Interaclable
{
    private bool visible = true;
    public GameObject roof;

    protected override void Update()
    {
        if (visible)
            roof.SetActive(true);
        else if (!visible)
            roof.SetActive(false);
        
    }
    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player hits collider");
            if (!visible)
                visible = true;
            else if (visible)
                visible = false;
        }
    }
}
