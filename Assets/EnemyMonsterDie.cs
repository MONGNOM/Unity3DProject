using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterDie : StateMachineBehaviour
{
    public Enemy enemy;
    [SerializeField]
    private float dieTime;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy = animator.GetComponent<Enemy>();
        enemy.agent.velocity = Vector3.zero;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dieTime += Time.deltaTime;
        if (dieTime >= 1.5f)
        {
            Destroy(animator.gameObject);
        }
       
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

}
