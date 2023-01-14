using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterTakehit : StateMachineBehaviour
{
    public Enemy enemy;
    
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();

        if (enemy.curhp <= 0)
            animator.SetTrigger("Die");
        else if (null != enemy.tower || null != enemy.teamMonster || null != enemy.playerController)
            animator.SetTrigger("Attack");
        else
            animator.SetTrigger("Move");

    }


}
