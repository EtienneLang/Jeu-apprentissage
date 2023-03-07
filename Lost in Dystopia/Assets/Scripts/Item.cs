using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Lootable
{

    public string nom;
    public GameObject prefab;
    public int id;

    public virtual void SpawnItem(Vector3 position) 
    {
        
    }

}
