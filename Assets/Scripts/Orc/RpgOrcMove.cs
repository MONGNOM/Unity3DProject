using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class RpgOrcMove : StateMachineBehaviour
{
    [SerializeField]
    private PlayerController controller;

    private RpgEnemy rpgEnemy;

 

    [SerializeField]
    private float attackRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy = animator.GetComponent<RpgEnemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy.agent = animator.GetComponent<NavMeshAgent>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rpgEnemy.agent.destination = controller.transform.position;
        Debug.Log("오크가 플레이어 위치로 이동함");

        Collider[] colliders = Physics.OverlapSphere(animator.gameObject.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            controller = colliders[i].GetComponent<PlayerController>();
            if (null != controller)
            {
                animator.SetBool("Move", false);
                animator.SetTrigger("Attack");
                break;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy.agent.ResetPath();
    }


}
