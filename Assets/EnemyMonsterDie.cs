using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMonsterDie : StateMachineBehaviour
{
    public Enemy enemy;
    [SerializeField]
    private float dieTime;

    [SerializeField]
    public int monsterexp;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerStatusManager.Instance.ExpUp(monsterexp);
        enemy = animator.GetComponent<Enemy>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.agent.velocity = Vector3.zero;
        dieTime += Time.deltaTime;
        if (dieTime >= 1.5f)
        {
            Destroy(animator.gameObject);
        }
       
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SpawnManager.Instance.GainMineral(Random.Range(1,50));
    }

}
