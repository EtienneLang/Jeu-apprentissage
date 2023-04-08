using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class slot : MonoBehaviour, IDropHandler
{
    private AudioSource sonDrop;
    private Inventory inventory;
    public int i;



    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
        else
        {
            inventory.isFull[i] = true;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            Debug.Log("Entré");
            //sonDrop.Play();
            child.GetComponent<Drop>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount == 0)
            {
                GameObject dropped = eventData.pointerDrag;
                DragDrop draggable = dropped.GetComponent<DragDrop>();
                draggable.parentAfterDrag = transform;
            }
        }
    }
}
