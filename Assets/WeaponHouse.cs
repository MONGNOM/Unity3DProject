using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHouse : MonoBehaviour
{
    public GameObject sword;

    public void ShowSword()
    {
        sword.gameObject.SetActive(false);
    }
    public void HideSword()
    {
        sword.gameObject.SetActive(true);
    }
}
