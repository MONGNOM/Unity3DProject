using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RpgBossHpDown : MonoBehaviour
{
    [SerializeField]
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
        monster = GameObject.FindGameObjectWithTag("RpgBoss").GetComponent<RpgEnemy>();
        hpbar.maxValue = monster.maxHp;
        hpbar.value = monster.curHp;
        if (monster.curHp <= 0)
            gameObject.SetActive(false);

    }


}
