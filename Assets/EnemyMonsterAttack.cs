using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMonsterAttack : StateMachineBehaviour
{
    public Animator animator;
    public Enemy enemy;
    public GameObject gameObject;
    public PlayerController playerController;
    [SerializeField]
    private TeamMonster target;
    [SerializeField]
    private float attackrange;
    private MyTower myTower;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        enemy = animator.GetComponent<Enemy>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {if (enemy.curhp <= 0)
            animator.SetTrigger("Die");
        FindTargetAttack();
    }
    private void FindTargetAttack()
    {
        playerController = null;
        target = null;
        Collider[] colliders = Physics.OverlapSphere(enemy.transform.position, attackrange);
        for (int i = 0; i < colliders.Length; i++)
        {
            playerController = colliders[i].GetComponent<PlayerController>();
            target = colliders[i].GetComponent<TeamMonster>();
            if (null != target)
            {
                animator.SetTrigger("Attack");
                enemy.transform.LookAt(target.transform.position);
                enemy.agent.destination = target.transform.position;
                break;
            }
            else if (null != playerController)
            {
                animator.SetTrigger("Attack");
                enemy.transform.LookAt(playerController.transform.position);
                enemy.agent.destination = playerController.transform.position;
                break;
            }
            else if (null == target && null == playerController)
            {
                myTower = GameObject.FindGameObjectWithTag("MyTower").GetComponent<MyTower>();
                enemy.transform.LookAt(myTower.transform.position);
                enemy.agent.destination = myTower.transform.position;
                break;
            }
            else
                animator.SetTrigger("Idle");

        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}

   