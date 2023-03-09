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

    private void Awake()
    {
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy = animator.GetComponentInChildren<RpgEnemy>();
        rpgEnemy.agent = animator.GetComponentInChildren<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy.agent = animator.GetComponentInChildren<NavMeshAgent>();
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
                Debug.Log("찾았는데");
                break;

            }
            else
                rpgEnemy.agent.enabled = true;


        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rpgEnemy.agent.enabled = false;
    }


}
