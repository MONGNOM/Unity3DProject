using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyMonsterMove : StateMachineBehaviour
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
        myTower = animator.GetComponent<MyTower>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.curhp <= 0)
            animator.SetTrigger("Die");
        FindTargetMove();
    }
    private void FindTargetMove()
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
                Debug.Log("팀몬스터가 공격범위안에 들어옴.");
                enemy.transform.LookAt(target.transform.position);
                enemy.agent.destination = target.transform.position;
                break;
            }
            else if (null != playerController)
            {
                animator.SetTrigger("Attack");
                Debug.Log("팀플레이어가 공격범위안에 들어옴");
                enemy.transform.LookAt(playerController.transform.position);
                enemy.agent.destination = playerController.transform.position;
                break;
            }
            else
            {
                Debug.Log("타워공격범위안에 들어옴");
                myTower = GameObject.FindGameObjectWithTag("MyTower").GetComponent<MyTower>();
                enemy.agent.destination = myTower.transform.position;
                enemy.transform.LookAt(myTower.transform.position);
                animator.SetTrigger("Idle");
                break;
            }
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
