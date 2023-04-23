using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditorInternal;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int coins;
    public Inventory inventaire;
    private GameObject UI_inventaire;
    public List<GameObject> prefabs_item_List;
    private void Start()
    {
        UI_inventaire = GameObject.FindGameObjectWithTag("UI");
        inventaire = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveToJson();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadFromJson();
        }
    }
    public void SaveToJson()
    {
        
        string itemForSave = "";
        foreach (Item item in inventaire.items)
        {
            itemForSave += $"{item.id}; {item.parentSlot}\n";
        }
        Debug.Log(itemForSave);
       // string inventoryData = JsonUtility.ToJson(itemForSave);
        string filePath = Application.persistentDataPath + "/inventoryData.json";

        File.WriteAllText(filePath, itemForSave);
        Debug.Log("Sauvegarde effectuée");
    }
    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/inventoryData.json";
        string inventoryData = File.ReadAllText(filePath);

        string[] vectLignes = inventoryData.Split('\n');
        for (int i = 1; i < vectLignes.Length-1; i++)
        {
            string[] vectContenuItem = vectLignes[i].Split(';');
            int idItem = Convert.ToInt32(vectContenuItem[0]);
            int index_slot = Convert.ToInt32(vectContenuItem[1]);
            Debug.Log(idItem);
            Debug.Log(index_slot);
            switch (idItem) 
            {
                //On peux optimiser cette fonction en mettant l'item dans la prefabs_item_list
                //à la même position que son id, du genre : 
                //Instantiate(prefabs_item_List[id_item], inventaire.slots[index_slot].transform, false);
                case 1:
                    Instantiate(prefabs_item_List[2], inventaire.slots[index_slot].transform, false);
                    break;
                case 2:
                    Instantiate(prefabs_item_List[3], inventaire.slots[index_slot].transform, false);
                    break;
                case 3:
                    Instantiate(prefabs_item_List[4], inventaire.slots[index_slot].transform, false);
                    break;
                case 4:
                    Instantiate(prefabs_item_List[5], inventaire.slots[index_slot].transform, false);
                    break;
                case 5:
                    Instantiate(prefabs_item_List[6], inventaire.slots[index_slot].transform, false);
                    break;
                case 6:
                    Instantiate(prefabs_item_List[7], inventaire.slots[index_slot].transform, false);
                    break;
                case 101:
                    Instantiate(prefabs_item_List[0], inventaire.slots[index_slot].transform, false);
                    break;
                case 102:
                    Instantiate(prefabs_item_List[1], inventaire.slots[index_slot].transform, false);
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Chargement effectué");
    }
    
}
