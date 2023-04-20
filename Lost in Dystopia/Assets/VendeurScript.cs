using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendeurScript : Interaclable
{
    // Start is called before the first frame update
    private bool _shopAffiche;
    public GameObject ShopUI;


    private void Start()
    {
        _shopAffiche = false;
        ShopUI.SetActive(false);
    }
    private void Update()
    {
        if (isInRange) 
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!_shopAffiche)
                {
                    ShopUI.SetActive(true);
                    _shopAffiche = true;
                }
                else
                {
                    ShopUI.SetActive(false);
                    _shopAffiche = false;
                }
            }
        }
        else if(_shopAffiche && !isInRange)
        {
            ShopUI.SetActive(false);
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
