using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RpgOrcIdle : StateMachineBehaviour
{
    private PlayerController controller;

    [SerializeField]
    private float findRange;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = null;
        Collider[] colliders = Physics.OverlapSphere(animator.gameObject.transform.position, findRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            controller = colliders[i].GetComponent<PlayerController>(); 
            if (null != controller)
            {
                animator.SetBool("Move",true);
                Debug.Log("��ũ�� �÷��̾ ã��");
                Debug.Log("���Ⱑ����22");
                break;
                // ���Ⱑ Idle �ڵ�â
            }
        }
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Idle", false);
    }


}