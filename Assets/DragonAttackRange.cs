using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class DragonAttackRange : StateMachineBehaviour
{

    [SerializeField]
    private PlayerController controller;

    private RpgEnemy rpgEnemy;

    [SerializeField]
    private float attackRange;

 
  
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        rpgEnemy = animator.GetComponentInChildren<RpgEnemy>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        rpgEnemy.agent = animator.GetComponentInChildren<NavMeshAgent>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Collider[] colliders = Physics.OverlapSphere(animator.gameObject.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            controller = colliders[i].GetComponent<PlayerController>();
            if (null != controller)
            {
                animator.gameObject.transform.LookAt(controller.transform.position);
                animator.SetBool("Move", false);
                animator.SetTrigger("Attack");
                break;

            }
            else
                animator.SetBool("Move", true);
        }

    }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
      
    }

}
