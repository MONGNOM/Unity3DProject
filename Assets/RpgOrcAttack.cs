using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RpgOrcAttack : StateMachineBehaviour
{
    private PlayerController controller;


    [SerializeField]
    private float attackRange;

    [SerializeField]
    private float damage;



    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
         
   }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        Collider[] colliders = Physics.OverlapSphere(animator.gameObject.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            controller = colliders[i].GetComponent<PlayerController>();
            if (null == controller)
            {
                animator.SetTrigger("Attack");
                Debug.Log("여기가범인11");
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
                animator.SetBool("Move",true);
    }




}
