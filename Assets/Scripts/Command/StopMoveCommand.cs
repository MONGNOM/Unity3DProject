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
        unitMovement.agent.velocity = Vector3.zero; // �̵��ӵ� 0
        unitMovement.agent.isStopped = true;        // �̵� ����
        teamMonster.attack = false;                 // ���� ����
       
        Debug.Log("���Ͱ� ��� ������ �����մϴ�.");
    }
   
}
