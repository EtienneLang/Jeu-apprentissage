using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    private List<StillText> stillTexts = new List<StillText>();

    private FloatingText GetFloatingText() 
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);
        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();
            floatingTexts.Add(txt);
        }

        return txt;
    }

    private StillText GetStillText() 
    {
        StillText txt = stillTexts.Find(t => !t.active);
        if (txt == null)
        {
            txt = new StillText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();
            stillTexts.Add(txt);
        }
        return txt;
    }

    private void Update()
    {
        foreach (FloatingText text in floatingTexts)
        {
            text.UpdateText();
        }
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) 
    {
        FloatingText floatingText = GetFloatingText();
        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingText.motion = motion;
        floatingText.duration = duration;
        floatingText.Show();
        
    }

    public void Hide()
    {
        foreach (StillText stillText in stillTexts)
        {
            if (stillText.active)
            {
                stillText.Hide();
            }
        }
    }

    public void ShowStillText(string msg, int fontSize, Color color, Vector3 position) 
    {
        StillText stillText = GetStillText();
        stillText.txt.text = msg;
        stillText.txt.fontSize = fontSize;
        stillText.txt.color = color;
        Vector3 truePostition = position + new Vector3(0, 0.5f, 0);
        stillText.go.transform.position = Camera.main.WorldToScreenPoint(truePostition);
        stillText.Show();
    }
}
