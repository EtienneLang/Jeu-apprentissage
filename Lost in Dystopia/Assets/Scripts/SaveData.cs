using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int coins;
    public Inventory inventaire;
    public List<Item> items;
    public GameObject Ui_inventaire;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveToJson();
        }
    }
    public void SaveToJson()
    {
        string inventoryData = JsonUtility.ToJson(inventaire);
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        Debug.Log(filePath);

        File.WriteAllText(filePath, inventoryData);
        Debug.Log("Sauvegarde effectuée");
    }
    // Start is called before the first frame update
    
}
