using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpbarDown : MonoBehaviour
{
    [SerializeField]
    private TeamMonster monster;

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
