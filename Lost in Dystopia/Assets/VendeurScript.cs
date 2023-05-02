using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendeurScript : Interaclable
{
    // Start is called before the first frame update
    private bool _shopBtnAffiche;
    private bool _shopSellAffiche;
    public GameObject ShopBtnUI;
    public GameObject ShopBuyUI;


    private void Start()
    {
        _shopBtnAffiche = false;
        _shopSellAffiche = false;
        ShopBtnUI.SetActive(false);
    }
    private void Update()
    {
        if (isInRange) 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!_shopBtnAffiche)
                {
                    ShopBtnUI.SetActive(true);
                    _shopBtnAffiche = true;
                }
                else
                {
                    ShopBtnUI.SetActive(false);
                    _shopBtnAffiche = false;
                }
            }
        }
        else if(_shopBtnAffiche && !isInRange)
        {
            ShopBtnUI.SetActive(false);
        }
        
    }
    public void ClickSell()
    {
        if (!_shopSellAffiche)
        {
            ShopBuyUI.SetActive(true);
            ShopBtnUI.transform.position = new Vector2 (Screen.width/2-300, Screen.height/2);    
            _shopSellAffiche = true;
        }
        else
        {
            ShopBuyUI.SetActive(false);
            ShopBtnUI.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);
            _shopSellAffiche = false;
        }
            
        
    }
    //NE MARCHE PAS JE NE SAIS PAS POURQUOI
    //protected new void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GameManager.instance.ShowStillText("Press M to open the map", 25, Color.white, GameManager.instance.player.transform.position);
    //    }
    //}

    //protected new void OnTriggerExit2D(Collider2D collision)
    //{
    //    GameManager.instance.HideText();
    //}


}
