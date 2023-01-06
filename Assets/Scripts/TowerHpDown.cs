using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHpDown : MonoBehaviour
{

    public Slider hpbar;

    private void Update()
    {
        HpDown();
    }
    private void HpDown()
    {
      
        hpbar.value = WaveManager.Instance.Heart;
    }
}
