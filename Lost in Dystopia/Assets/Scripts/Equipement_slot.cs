using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Equipement_slot : MonoBehaviour, IDropHandler
{
    private Transform gun;
    public GameObject glock;
    public GameObject ak;
    public GameObject glock_UI;
    private GameObject player;
    private Transform aimTransform;
    private Transform[] ts;
    private bool gunSpawned = true;
    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponentsInChildren<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        aimTransform = player.transform.Find("Aim");
        Instantiate(glock_UI, transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(ts.Length);
        ts = GetComponentsInChildren<Transform>();
        if (ts.Length == 1 && gunSpawned)
        {
            gunSpawned = false;
            Debug.Log("Pas d'enfant");
            Destroy(aimTransform.gameObject);
        }
        else
        {
            //VerifierArme();
        } 
    }
    private void VerifierArme()
    {
        if (!gunSpawned)
        {
            if (aimTransform.name == "Aim")
            {
                Instantiate(glock, player.transform.position, Quaternion.identity, player.transform);
                gunSpawned=true;
            }
            else if (aimTransform.name == "AK_Prefab")
            {
                Instantiate(ak, player.transform.position, Quaternion.identity, player.transform);
                gunSpawned = true;
            }
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
