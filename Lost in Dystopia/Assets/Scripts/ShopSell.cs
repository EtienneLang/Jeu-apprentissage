using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopSell : MonoBehaviour
{
    private VerticalLayoutGroup itemListScoller;
    private Inventory inventaire;
    public GameObject medSellButton;
    // Start is called before the first frame update
    void Start()
    {
        inventaire = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
        itemListScoller = GameObject.Find("SellItemPanel").GetComponent<VerticalLayoutGroup>();
    }
    private void Update()
    {
//        Debug.Log(inventaire.items.Count);
    }
    public void RefreshSellScroller()
    {
        foreach (Transform child in itemListScoller.transform)
        {
            Destroy(child.gameObject);
        }
        if (inventaire != null) 
        {
            foreach (Item item in inventaire.items)
            {
                if (item.nom == "med_item")
                {
                    Instantiate(medSellButton, itemListScoller.transform);
                }
            }
        }
        
    }
}
