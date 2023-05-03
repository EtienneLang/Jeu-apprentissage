using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopSell : MonoBehaviour
{
    private VerticalLayoutGroup itemListScoller;
    private List<Item> itemList;
    public GameObject medSellButton;
    // Start is called before the first frame update
    void Start()
    {
        itemList = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>().items;
        itemListScoller = GameObject.Find("SellItemPanel").GetComponent<VerticalLayoutGroup>();
    }
    public void RefreshSellScroller()
    {
        foreach (Item item in itemList) 
        {
            if (item.nom == "med_item") 
            {
                Instantiate(medSellButton,itemListScoller.transform);
            }
        }
    }
}
