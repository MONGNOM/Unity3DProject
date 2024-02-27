using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMonsterIdle : StateMachineBehaviour
{
    public Animator animator;
    public Enemy enemy;
    public PlayerController playerController;
    private TeamMonster target;
    [SerializeField]
    private float findrange;
    private MyTower myTower;

   
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        enemy = animator.GetComponent<Enemy>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.curhp <= 0)
            animator.SetTrigger("Die");
        FindTargetIdle();
    }
    private void FindTargetIdle()
    {
        playerController = null;
        target = null;
        Collider[] colliders = Physics.OverlapSphere(enemy.transform.position, findrange);
        for (int i = 0; i < colliders.Length; i++)
        {
            playerController = colliders[i].GetComponent<PlayerController>();
            target = colliders[i].GetComponent<TeamMonster>();
            if (null != target)
            {
                animator.SetTrigger("Move");
                enemy.transform.LookAt(target.transform.position);
                enemy.agent.destination = target.transform.position;
                break;
            }
            else if (null != playerController)
            {
                animator.SetTrigger("Move");
                enemy.agent.destination = playerController.transform.position;
                enemy.transform.LookAt(playerController.transform.position);
                break;
            }
            else if (null != myTower)
            {
                animator.SetTrigger("Move");
                enemy.agent.destination = myTower.transform.position;
                enemy.transform.LookAt(myTower.transform.position);
                break;
            }


        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
