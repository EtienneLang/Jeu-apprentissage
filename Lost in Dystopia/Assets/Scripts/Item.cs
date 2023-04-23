using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public string nom;
    public GameObject prefab;
    public int id;
    public int parentSlot;

    private void Update()
    {
        if (GetComponentInParent<slot>() != null)
            parentSlot = GetComponentInParent<slot>().i;
    }
    public virtual void SpawnItem(Vector3 position) 
    {
        
    }

}
