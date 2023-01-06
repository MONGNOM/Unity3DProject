using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoldMoveCommand : ICommandable
{
    public UnitMovement unitMovement;// 1.일단 가져온다 
    public TeamMonster teamMonster;
    public HoldMoveCommand(UnitMovement unitMovement, TeamMonster teamMonster) // 생성자에서 유닛컴퍼넌트 가져오는 방법 2. 이렇게 추가해준다.  
    {
        this.unitMovement = unitMovement;
        this.teamMonster = teamMonster;
    }
    public void Execute()
    {
        Hold();
    }

    public void Hold()
    {
        unitMovement.agent.velocity = Vector3.zero; // 이동속도 0
        unitMovement.agent.isStopped = true;
        teamMonster.attack = true;              // 공격 가능
        Debug.Log("몬스터가 제자리에서 행동합니다");
    }
}
