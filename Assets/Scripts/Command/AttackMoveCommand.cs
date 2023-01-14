using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackMoveCommand : MonoBehaviour,ICommandable
{
    public TeamMonster teamMonster;
    public UnitMovement unitMovement;
    public MeleeAttackMonster meleeAttack;
    public AttackMoveCommand(UnitMovement unitMovement, TeamMonster teamMonster, MeleeAttackMonster meleeAttack)
    {
        this.teamMonster = teamMonster;
        this.unitMovement = unitMovement;
        this.meleeAttack = meleeAttack; 
    }

    
    public void Execute()
    {
        if (meleeAttack.enemyTower || meleeAttack.target)
            Attack();
        else
            return;
    }

    
    void Attack()
    {
        teamMonster.anim.SetTrigger("Attack");
    }
}
