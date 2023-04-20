using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Jobs;
using UnityEngine.SceneManagement;

public class Equipement_slot : MonoBehaviour, IDropHandler
{
    private Transform gun;
    public GameObject glock;
    public GameObject ak;
    public GameObject glock_UI;
    private GameObject player;
    private Transform aimTransform;
    private Transform[] ts;
    private PlayerAim playerAimScript;
    private bool gunSpawned;
    private Scene scene;
    private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        LoadAllObjectForScript();
    }

    // Update is called once per frame
    void Update()
    {
        ts = GetComponentsInChildren<Transform>();
        Debug.Log(ts.Length);
        if (ts.Length == 1 && gunSpawned)
        {
            gunSpawned = false;
            for (int i = 0; i < 2; i++)
            {
                player.transform.GetChild(i).gameObject.SetActive(false);
            }
            playerAimScript.ChangeGun("");

        }
        else
            VerifierArme();

        //On reload le script si on change de scene
        if (scene.name != sceneName)
            LoadAllObjectForScript();
    }
    private void VerifierArme()
    {
        if (!gunSpawned)
        {
            // Debug.Log(player.transform.GetChild(0).gameObject.activeInHierarchy);
            if (ts[0].transform.Find("Glock_Inventory(Clone)") || ts[0].transform.Find("Glock_Inventory"))
            {
                DisableAllGunsExept(0);
                player.transform.GetChild(0).gameObject.SetActive(true);
                playerAimScript.ChangeGun("Glock");
                gunSpawned = true;
            }
            else if (ts[0].transform.Find("Ak_Inventory(Clone)") || ts[0].transform.Find("Ak_Inventory"))
            {
                DisableAllGunsExept(1);
                player.transform.GetChild(1).gameObject.SetActive(true);
                playerAimScript.ChangeGun("AK");
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

    public void DisableAllGunsExept(int indice)
    {
        for (int i = 0; i < 2; i++)
        {
            if (i != indice)
            {
                player.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    private void LoadAllObjectForScript() {
        ts = GetComponentsInChildren<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAimScript = player.GetComponent<PlayerAim>();
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

}
