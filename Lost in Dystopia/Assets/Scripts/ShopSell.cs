using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShopSell : MonoBehaviour
{
    private GameObject itemListScoller;
    private Inventory inventaire;
    public GameObject medSellButton;
    public GameObject CigSellButton;
    public GameObject CrystalSellButton;
    public GameObject GlockSellButton;
    public GameObject AKSellButton;
    public GameObject PilsSellButton;
    public GameObject MoneySellButton;
    public GameObject KeySellButton;
    // Start is called before the first frame update
    void Start()
    {
        inventaire = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
        itemListScoller = GameObject.FindGameObjectWithTag("SellItemPanel");
    }
    private void Update()
    {
//        Debug.Log(inventaire.items.Count);
    }
    public void RefreshSellScroller() 
    {
        itemListScoller = GameObject.FindGameObjectWithTag("SellItemPanel");
        Debug.Log(itemListScoller.transform.childCount);
        if (itemListScoller.transform.childCount != 0)
        {
            foreach (Transform child in itemListScoller.transform)
            {
                Destroy(child.gameObject);
            }
        }
        if (inventaire != null) 
        {
            foreach (Item item in inventaire.items)
            {
                switch (item.nom)
                {
                    case "med_item":
                        Instantiate(medSellButton, itemListScoller.transform);
                        break;
                    case "cig_item":
                        Instantiate(CigSellButton, itemListScoller.transform);
                        break;
                    case "crystal_item":
                        Instantiate(CrystalSellButton, itemListScoller.transform);
                        break;
                    case "glock_item":
                        Instantiate(GlockSellButton, itemListScoller.transform);
                        break;
                    case "Ak_item":
                        Instantiate(AKSellButton, itemListScoller.transform);
                        break;
                    case "pils_item":
                        Instantiate(PilsSellButton, itemListScoller.transform);
                        break;
                    case "money_item":
                        Instantiate(MoneySellButton, itemListScoller.transform);
                        break;
                    case "key_item":
                        Instantiate(KeySellButton, itemListScoller.transform);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
