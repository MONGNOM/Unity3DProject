using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AttackMoveCommand : MonoBehaviour,ICommandable
{
    public TeamMonster teamMonster;
    public UnitMovement unitMovement;
    public AttackMoveCommand(UnitMovement unitMovement, TeamMonster teamMonster)
    {
        this.teamMonster = teamMonster;
        this.unitMovement = unitMovement;
    }
    public void Execute()
    {
        Attack();
    }

    void Attack()
    {

        unitMovement.agent.isStopped = false;
        teamMonster.attack = true; // ���� ����
        Debug.Log("���Ͱ� �����ϸ鼭 ��ǥ �������� �̵��մϴ�");
    }
}
