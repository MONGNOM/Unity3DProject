using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHand : MonoBehaviour
{
    public Weapon sword;


    public WeaponHand(Weapon sword)
    { 
        this.sword = sword;
    }
    

    public void ShowSword()
    {
        sword.gameObject.SetActive(true);
    }
    public void HideSword()
    {
        sword.gameObject.SetActive(false);
    }

}
