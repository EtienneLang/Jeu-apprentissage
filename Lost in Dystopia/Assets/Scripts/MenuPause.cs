using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{

    public static bool JeuEnPause = false;
    public GameObject MenuPauseUI;
    public SaveData inventaireSaveData;
    private void Start()
    {
        inventaireSaveData = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<SaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (JeuEnPause)
            {
                ContinuerJeu();
            }
            else
            {
                MettreJeuEnPause();
            }
        }
    }

    /// <summary>
    /// Permets de continuer le jeu
    /// </summary>
    public void ContinuerJeu() 
    {
        MenuPauseUI.SetActive(false);
        Time.timeScale = 1f;
        JeuEnPause = false;
    }

    /// <summary>
    /// Permets de mettre le jeu en pause
    /// </summary>
    public void MettreJeuEnPause()
    {
        MenuPauseUI.SetActive(true);
        Time.timeScale = 0f;
        JeuEnPause = true;
    }

    /// <summary>
    /// Permets de quitter le jeu
    /// </summary>
    public void QuitterJeu() 
    {
        Application.Quit();
    }

    /// <summary>
    /// Permets de retourner au menu principal
    /// </summary>
    public void RetournerMenuPrincipal() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
