using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[3,10];
    public GameObject[] itemsPrefabs = new GameObject[5];
    public Text coinsTxt;
    public GameObject player;
    private int playerCoins;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        Player playerScript = player.GetComponent<Player>();
        playerCoins = playerScript.GoldCoins;
        coinsTxt.text = playerCoins.ToString();
        inventory = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();

        //Id's
        shopItems[0,0] = 1; //Med
        shopItems[0,1] = 2; //Key
        shopItems[0,2] = 3; //AK
        shopItems[0,3] = 4; //Pils
        shopItems[0,4] = 5; //Glock
        shopItems[0,5] = 6; //Cig
        shopItems[0,6] = 7; //Money
        shopItems[0,7] = 8; //Crystal

        //Prices
        shopItems[1,0] = 10;
        shopItems[1,1] = 20;
        shopItems[1,2] = 100;
        shopItems[1,3] = 20;
        shopItems[1,4] = 80;

        //SellPrice
        shopItems[2, 0] = 7;
        shopItems[2, 1] = 15;
        shopItems[2, 2] = 60;
        shopItems[2, 3] = 15;
        shopItems[2, 4] = 40;
        shopItems[2, 5] = 20;
        shopItems[2, 6] = 40;
        shopItems[2, 7] = 70;
    }

    // Update is called once per frame
    public void Buy() 
    {
        Debug.Log("Buy");
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if (playerCoins >= shopItems[1, buttonRef.GetComponent<ButtonInfo>().ItemID])
        {
            playerCoins -= shopItems[1, buttonRef.GetComponent<ButtonInfo>().ItemID];
            coinsTxt.text = playerCoins.ToString();

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Debug.Log("rammassé");
                    inventory.isFull[i] = true;
                    inventory.items.Add(Instantiate(itemsPrefabs[buttonRef.GetComponent<ButtonInfo>().ItemID], inventory.slots[i].transform, false).GetComponent<Item>());
                    break;
                }
            }
        }
    }

    public void Sell()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        playerCoins += shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
        coinsTxt.text = playerCoins.ToString();
        bool trouve = false;
        for (int j = 0; j < inventory.slots.Length; j++)
        {
            if (inventory.slots[j].transform.childCount > 0)
            {
                Debug.Log(inventory.slots[j].transform.GetChild(0).GetComponent<Item>().id);
                Debug.Log(buttonRef.GetComponent<ButtonInfo>().ItemID);

                if (inventory.slots[j].transform.GetChild(0).GetComponent<Item>().id == buttonRef.GetComponent<ButtonInfo>().ItemID && !trouve)
                {

                    inventory.isFull[j] = false;
                    Destroy(inventory.slots[j].transform.GetChild(0).gameObject);
                    Destroy(buttonRef.transform.parent.gameObject);
                    //On dois supprimer l'item de la liste d'item (A faire)à
                    inventory.items.Remove(inventory.slots[j].transform.GetChild(0).GetComponent<Item>());
                    //inventory.items.Remove(buttonRef.transform.parent.gameObject.GetComponent<Item>());
                    trouve = true;
                }
            }   
        }
    }
}
