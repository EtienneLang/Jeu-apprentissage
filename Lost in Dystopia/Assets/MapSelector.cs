using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : Interaclable
{
    private bool _MapAffiche;
    public GameObject MapUI;
    private void Start()
    {
        _MapAffiche = false;
        MapUI.SetActive(false);
    }
    private void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (!_MapAffiche)
                {
                    MapUI.SetActive(true);
                    _MapAffiche = true;
                }
                else
                {
                    MapUI.SetActive(false);
                    _MapAffiche = false;
                }
            }
        }
    }

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

    public void villageSelect()
    {
        GameManager.instance.HideText();
        SceneManager.LoadScene(1);
    }
}
