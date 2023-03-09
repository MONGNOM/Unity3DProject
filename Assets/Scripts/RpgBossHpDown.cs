using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RpgBossHpDown : MonoBehaviour
{
    private RpgEnemy monster;

    public Slider hpbar;
    

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        HpDown();
    }
    private void HpDown()
    {
        monster = GameObject.FindWithTag("RpgBoss").GetComponentInChildren<RpgEnemy>();
        hpbar.maxValue = monster.maxHp;
        hpbar.value = monster.curHp;
        if (monster.curHp <= 0)
        {
            hpbar.maxValue = 0;
            gameObject.SetActive(false);
        }

    }


}
