using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public GameObject Ui_inventory;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }
}

