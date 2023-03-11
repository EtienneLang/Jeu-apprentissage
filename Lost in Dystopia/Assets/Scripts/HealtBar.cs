using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider; 

    public void SetHealt(int health) 
    {
        slider.value = health;
    }

    public void SetMaxHealth(int maxhealth) 
    {
        slider.maxValue = maxhealth;
        slider.value = maxhealth;
    }


}
