using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public GameObject medKit;
    public GameObject BaseEnnemy;

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

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public static void ajouterCoins(int nbGoldCoins) 
    {
        instance.player.goldCoins += nbGoldCoins;
    }

    public static void SpawnMedkit(Transform transform) 
    {
        Instantiate(instance.medKit,transform.position, Quaternion.identity);
    }

    public static void SpawnBaseEnnemy(Vector3 position) 
    {
        
        Instantiate(instance.BaseEnnemy, position , Quaternion.identity);
    }

}
