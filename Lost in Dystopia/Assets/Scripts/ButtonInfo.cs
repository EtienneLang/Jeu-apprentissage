using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text priceTxt;
    public GameObject ShopManager;


    // Update is called once per frame
    void Update()
    {
        priceTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[1, ItemID].ToString();
    }
}
