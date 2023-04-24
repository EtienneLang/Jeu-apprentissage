using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSave : MonoBehaviour
{
    public SaveData inventaireSaveData;
    public Button button;
    public Inventory inventaire;
    // Start is called before the first frame update
    void Start()
    {
        inventaire = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<Inventory>();
        Button btn = button.GetComponent<Button>();
        if (btn.name == "BoutonSauvegarder")
            btn.onClick.AddListener(SaveOnClick);
        else
            btn.onClick.AddListener(LoadOnClick);
        
        inventaireSaveData = GameObject.FindGameObjectWithTag("Inventaire").GetComponent<SaveData>();
    }
    private void SaveOnClick()
    {
        inventaireSaveData.SaveToJson();
    }

    private void LoadOnClick()
    {
        foreach (GameObject slot in inventaire.slots) 
        {
            foreach (Transform child in slot.transform)
                Destroy(child.gameObject);
        }
        inventaire.items.Clear();
        inventaireSaveData.LoadFromJson();
    }
}
