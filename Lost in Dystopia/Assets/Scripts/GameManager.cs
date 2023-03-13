using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public GameObject medKit;
    public GameObject baseEnnemy;
    public GameObject key;
    public FloatingTextManager floatingTextManager;

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
        GameManager.instance.ShowText($"{nbGoldCoins}$", 30, Color.yellow, instance.player.transform.position, Vector3.up * 50, 3);
        GameManager.instance.HideText();
    }

    public static void SpawnMedkit(Transform transform) 
    {
        Instantiate(instance.medKit,transform.position, Quaternion.identity);
    }

    public static void SpawnBaseEnnemy(Vector3 position) 
    {
        
        Instantiate(instance.baseEnnemy, position , Quaternion.identity);
    }

    public static void SpawnKey(Vector3 position) 
    {
        Instantiate(instance.key, position, Quaternion.identity);
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void HideText() 
    {
        floatingTextManager.Hide();
    }



}
