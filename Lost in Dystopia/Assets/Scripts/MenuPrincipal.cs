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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }


    /// <summary>
    /// Permets de fermer le jeu
    /// </summary>
    public void FermerJeu() 
    {
        Application.Quit();
    }


}
