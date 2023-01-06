using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class StopMoveCommand : ICommandable
{
    public UnitMovement unitMovement;
    public TeamMonster teamMonster;

    public StopMoveCommand(UnitMovement unitMovement, 
                           TeamMonster teamMonster)
    {
        this.unitMovement = unitMovement;
        this.teamMonster = teamMonster;
    }
   
    public void Execute()
    {
        Stop();
    }

    public void Stop()
       
    {
        unitMovement.agent.velocity = Vector3.zero; // 이동속도 0
        unitMovement.agent.isStopped = true;        // 이동 정지
        teamMonster.attack = false;                 // 공격 안함
       
        Debug.Log("몬스터가 모든 동작을 정지합니다.");
    }
   
}
