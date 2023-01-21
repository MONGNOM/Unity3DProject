using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RpgEnemyHpDown : MonoBehaviour
{
    [SerializeField]
    private RpgEnemy monster;

    public Slider hpbar;

    private void Update()
    {
        HpDown();
    }
    private void HpDown()
    {
        hpbar.maxValue = monster.maxHp;
        hpbar.value = monster.curHp;
        if (monster.curHp <= 0)
            gameObject.SetActive(false);
    }
}
