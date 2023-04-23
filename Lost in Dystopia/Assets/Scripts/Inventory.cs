using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour
{
    
    public bool[] isFull;
    public GameObject[] slots;
    [SerializeField] public List<Item> items;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}

