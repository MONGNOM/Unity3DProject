using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackMoveCommand : MonoBehaviour,ICommandable
{
    public TeamMonster teamMonster;
    public UnitMovement unitMovement;
    public bool attack;
    public AttackMoveCommand(UnitMovement unitMovement, TeamMonster teamMonster)
    {
        this.teamMonster = teamMonster;
        this.unitMovement = unitMovement;
    }

    private void Update()
    {
        attack = true;
    }
    public void Execute()
    {
        Attack();
    }

    
    void Attack()
    {
        attack = true;
        unitMovement.agent.isStopped = false;
        teamMonster.attack = true; // 공격 가능
        Debug.Log("몬스터가 공격하면서 목표 지점으로 이동합니다");
    }
}
