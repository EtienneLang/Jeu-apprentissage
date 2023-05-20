using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public bool isBuying;
    public Text priceTxt;
    private ShopManagerScript ShopManager;
    private Button button;
    private void Start()
    {
        ShopManager = GameObject.FindGameObjectWithTag("ShopManager").GetComponent<ShopManagerScript>();
        if (isBuying == false) 
        {
            button = this.GetComponent<Button>();
            button.onClick.AddListener(ShopManager.Sell);
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if(isBuying == true)
            priceTxt.text = ShopManager.shopItems[1, ItemID].ToString();
        else
        {
            Debug.Log(ShopManager.shopItems[2, ItemID].ToString());
            priceTxt.text = ShopManager.shopItems[2, ItemID].ToString();
        }
    }
}
