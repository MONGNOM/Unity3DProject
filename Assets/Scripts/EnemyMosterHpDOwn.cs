using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyMosterHpDOwn : MonoBehaviour
{
    [SerializeField]
    private Enemy monster;

    public Slider hpbar;

    private void Update()
    {
        HpDown();
    }
    private void HpDown()
    {
        hpbar.maxValue = monster.maxhp;
        hpbar.value = monster.curhp;
    }
}
