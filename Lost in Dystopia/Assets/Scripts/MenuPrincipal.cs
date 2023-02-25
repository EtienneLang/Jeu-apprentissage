using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    /// <summary>
    /// Permets de commencer le jeu
    /// </summary>
    public void DemarrerJeu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void FermerJeu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log("Quitter le jeu");
        //Application.Quit();
    }


}
