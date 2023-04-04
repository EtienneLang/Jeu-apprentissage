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
        
    }
    // Update is called once per frame
    protected override void OnInteraction()
    {
        
    }
}
