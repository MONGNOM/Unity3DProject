using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MeleeAttackMonster : TeamMonster
{
    ICommandable meleeAttack;

    [Header("Spec")]
    [SerializeField]
    public int damage;
    [SerializeField]
    protected float range;
    [SerializeField]
    private float fireRagte;

    public EnemyTower enemyTower;

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        attack = true;
        enemyTower = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<EnemyTower>();
        UnitSelection.Instance.unitList.Add(this.gameObject);
        meleeAttack = new AttackMoveCommand(unit,this,this);
    }
    private void Update()
    {
        if (base.curhp <= 0)
            base.Die();
        else
            FindTarget();
    }
    protected void FindTarget()
    { // 어택 레인지도 만들어서 그 안에 들어오면 어택을 애니메이션 트리거 시키세요
        if (attack)
        {
            target = null;
            enemyTower = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                target = colliders[i].GetComponent<Enemy>();
                enemyTower = colliders[i].GetComponent<EnemyTower>();

                if (null != target)
                {

                    meleeAttack.Execute();
                    gameObject.transform.LookAt(target.transform.position);
                    agent.destination = target.transform.position;
                    Debug.Log("적군몬스터를 공격한다");
                }
                else if (null != enemyTower)
                {
                    meleeAttack.Execute();
                    gameObject.transform.LookAt(enemyTower.transform.position);
                    agent.destination = enemyTower.transform.position;
                    Debug.Log("적군 타워를 공격한다");

                }
            }
        }
        else
            return;
    }

}
