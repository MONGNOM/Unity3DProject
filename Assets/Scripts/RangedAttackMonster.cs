using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RangedAttackMonster : TeamMonster
{
    ICommandable rangedAttack;

    [SerializeField]
    public int damage;
    [SerializeField]
    protected float range;
    [SerializeField]
    private float fireRagte;

    public EnemyTower enemyTower;

    public bool maekfireball;
    
    private void Start()
    {
        enemyTower = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<EnemyTower>();
        UnitSelection.Instance.unitList.Add(this.gameObject);
        maekfireball = true;
        attack = true;
        rangedAttack = new Attackmarine(this, this);

    }

    private void Update()
    {
        if (!die)
            FindTarget();
    }
    protected void FindTarget()
    {
        if (attack)
        {
            maekfireball = false;
            target = null;
            enemyTower = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                target = colliders[i].GetComponent<Enemy>();
                enemyTower = colliders[i].GetComponent<EnemyTower>();
             
                if (null != target)
                {

                    Debug.Log("원거리 공격");
                    rangedAttack.Execute();
                    gameObject.transform.LookAt(target.transform.position);
                    break;
                }
                else if (null != enemyTower)
                {
                    Debug.Log("원거리 공격");
                    rangedAttack.Execute(); 
                    gameObject.transform.LookAt(enemyTower.transform.position);
                    break;
                }
                else
                    agent.destination = move.detination;
            }
        }
        else
            return;
    }

   

}
