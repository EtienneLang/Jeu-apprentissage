using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Fighter
{
    public GameObject medKit;

    protected override void Death()
    {
        Instantiate(medKit, transform.position, Quaternion.identity);
        base.Death();
    }

}
