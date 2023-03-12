using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public float stamina;
    public float maxStamina;
    public float sValue;

    public Slider staminaBar;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DecreaseStamina();
        }
        else if(stamina < maxStamina)
        {
            IncreaseStamina();
        }

        staminaBar.value = stamina;
    }

    private void DecreaseStamina()
    {
        if (stamina != 0)
        {
            stamina -= sValue * Time.deltaTime;
        }
    }
    private void IncreaseStamina()
    {
        stamina += sValue * Time.deltaTime;
    }
}
