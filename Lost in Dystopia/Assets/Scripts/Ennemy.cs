using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : Fighter
{

    protected override void Death()
    {
        GameManager.SpawnMedkit(transform);
        base.Death();
    }

}
