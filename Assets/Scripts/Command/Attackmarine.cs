using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackmarine : MonoBehaviour,ICommandable
{
    public TeamMonster monster;
    public RangedAttackMonster rangedAttack;


    public Attackmarine (TeamMonster monster, RangedAttackMonster rangedAttack)
    {
        this.monster = monster;
        this.rangedAttack = rangedAttack;
    }

  

    public void Execute()
    {
        if (rangedAttack.enemyTower || rangedAttack.target)
            Attack();
         else
            return; 
    }

    public void Attack()
    {

        Debug.Log("���Ÿ�����[Ŀ�ǵ� ���]");
        monster.agent.isStopped = true;
        monster.Takehit = false;
        rangedAttack.maekfireball = true;
        monster.anim.SetTrigger("Attack");
    }




}
