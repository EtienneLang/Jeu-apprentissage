using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
        else
        {
            inventory.isFull[i] = true;
        }

    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Drop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
