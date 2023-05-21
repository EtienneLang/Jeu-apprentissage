using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D curseurBase;
    [SerializeField] private Texture2D curseurMain;
    [SerializeField] private Texture2D curseurMainFerme;
    [SerializeField] private Texture2D curseurFleche;
    private GameObject menuPause;
    private GameObject menuShop;

    private bool baseActive = true;
    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        menuPause = GameObject.FindGameObjectWithTag("MenuPause");
        menuShop = GameObject.FindGameObjectWithTag("MenuShop");
        cursorHotspot = new Vector2(curseurBase.width / 2, curseurBase.height / 2);
        Cursor.SetCursor(curseurBase, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            menuShop = GameObject.FindGameObjectWithTag("MenuShop");
            menuPause = GameObject.FindGameObjectWithTag("MenuPause");
            baseActive = false;
            if (SceneManager.GetActiveScene().name == "MenuPrincipal" || menuPause != null || menuShop != null)
            {
                cursorHotspot = new Vector2(curseurFleche.width / 2, curseurFleche.height / 2);
                Cursor.SetCursor(curseurFleche, cursorHotspot, CursorMode.Auto);
            }
            
            else if (Input.GetMouseButton(0))
            {
                cursorHotspot = new Vector2(curseurMainFerme.width / 2, curseurMainFerme.height / 2);
                Cursor.SetCursor(curseurMainFerme, cursorHotspot, CursorMode.Auto);
            }
            else 
            {
                cursorHotspot = new Vector2(curseurMain.width / 2, curseurMain.height / 2);
                Cursor.SetCursor(curseurMain, cursorHotspot, CursorMode.Auto);
            }
            
        }
        else if(!baseActive)
        {
            cursorHotspot = new Vector2(curseurBase.width / 2, curseurBase.height / 2);
            Cursor.SetCursor(curseurBase, cursorHotspot, CursorMode.Auto);
            baseActive = true;
        }
    }
}
