using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private AudioSource sonRamasse;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
        sonRamasse = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    sonRamasse.pitch = Random.Range(0.8f, 1.2f);
                    sonRamasse.Play();
                    inventory.isFull[i] = true;
                    inventory.items.Add(Instantiate(itemButton, inventory.slots[i].transform, false).GetComponent<Item>());
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
