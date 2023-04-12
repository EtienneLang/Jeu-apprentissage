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
    public GameObject InventaireEtUI;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (GameObject.Find("DONTDESTROY") == null) 
        {
            Instantiate(InventaireEtUI);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        floatingTextManager = GameObject.FindGameObjectWithTag("TextManager").GetComponent<FloatingTextManager>();
    }
    private void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
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

    public void ShowStillText(string msg, int fontSize, Color color, Vector3 position) 
    {
        floatingTextManager.ShowStillText(msg, fontSize, color, position);
    }

    public void HideText() 
    {
        floatingTextManager.Hide();
    }



}
