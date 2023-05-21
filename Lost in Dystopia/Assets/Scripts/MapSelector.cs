using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelector : Interaclable
{
    private bool _MapAffiche;
    public GameObject MapUI;
    private bool _MsgAffiche;
    private void Start()
    {
        _MapAffiche = false;
        MapUI.SetActive(false);
    }
    private void Update()
    {
        if (isInRange)
        {
            if (!_MsgAffiche) 
            {
               GameManager.instance.ShowStillText("Press M to open the map", 25, Color.white, GameManager.instance.player.transform.position);
                _MsgAffiche = true;
            }
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
        else if(_MsgAffiche) 
            GameManager.instance.HideText();

    }


    public void villageSelect()
    {
        GameManager.instance.HideText();
        SceneManager.LoadScene(1);
    }
}
