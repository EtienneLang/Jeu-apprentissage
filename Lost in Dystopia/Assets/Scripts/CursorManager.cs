using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D curseurBase;
    [SerializeField] private Texture2D curseurMain;
    [SerializeField] private Texture2D curseurMainFerme;
    private bool baseActive = true;
    private Vector2 cursorHotspot;
    // Start is called before the first frame update
    void Start()
    {
        cursorHotspot = new Vector2(curseurBase.width / 2, curseurBase.height / 2);
        Cursor.SetCursor(curseurBase, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            baseActive = false;
            if (Input.GetMouseButton(0))
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
