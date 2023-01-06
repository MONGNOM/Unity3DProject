using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoldMoveCommand : ICommandable
{
    public UnitMovement unitMovement;// 1.�ϴ� �����´� 
    public TeamMonster teamMonster;
    public HoldMoveCommand(UnitMovement unitMovement, TeamMonster teamMonster) // �����ڿ��� �������۳�Ʈ �������� ��� 2. �̷��� �߰����ش�.  
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
        unitMovement.agent.velocity = Vector3.zero; // �̵��ӵ� 0
        unitMovement.agent.isStopped = true;
        teamMonster.attack = true;              // ���� ����
        Debug.Log("���Ͱ� ���ڸ����� �ൿ�մϴ�");
    }
}
