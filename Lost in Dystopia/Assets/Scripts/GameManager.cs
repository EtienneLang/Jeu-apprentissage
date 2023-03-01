using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        MedKit medKit = new MedKit();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public static void ajouterCoins(int nbGoldCoins) 
    {
        instance.player.goldCoins += nbGoldCoins;
    }

}
