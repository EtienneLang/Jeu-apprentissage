using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[2,5];
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
        shopItems[0,0] = 1;
        shopItems[0,1] = 2;
        shopItems[0,2] = 3;
        shopItems[0,3] = 4;
        shopItems[0,4] = 5;

        //Prices
        shopItems[1,0] = 10;
        shopItems[1,1] = 20;
        shopItems[1,2] = 100;
        shopItems[1,3] = 20;
        shopItems[1,4] = 80;
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
                    Instantiate(itemsPrefabs[buttonRef.GetComponent<ButtonInfo>().ItemID], inventory.slots[i].transform, false);
                    break;
                }
            }
        }
    }
}
