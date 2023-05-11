using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCountUI : MonoBehaviour
{
    public Text NbAmmoText;
    private int maxBullet;

    public void UpdateNbAmmo(int nbBullet)
    {
        NbAmmoText.text = $"{nbBullet}/{maxBullet}";
    }

    public void ChangeGun(int nbBullet) 
    {
        NbAmmoText.text = $"{nbBullet}/{nbBullet}";
        maxBullet = nbBullet;
    }
}
