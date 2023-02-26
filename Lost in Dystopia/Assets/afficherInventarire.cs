using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class afficherInventarire : MonoBehaviour
{
    private bool _inventaireAffiche;
    public GameObject GrosInventaireUI;


    private void Start()
    {
        _inventaireAffiche = false;
        GrosInventaireUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_inventaireAffiche)
            {
                GrosInventaireUI.SetActive(true);
                _inventaireAffiche = true;
            }
            else
            {
                GrosInventaireUI.SetActive(false);
                _inventaireAffiche = false;
            }
        }
    }
}



