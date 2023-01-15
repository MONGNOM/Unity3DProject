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
        Debug.Log(monsterexp + "경험치를 얻습니다");
        PlayerStatusManager.Instance.ExpUp(monsterexp);
        // 경험치 시스템을 아군 몬스터로 여기서는 아군몬스터로 주고 나는 rpg에서 경험치 받자
        SpawnManager.Instance.GainMineral(Random.Range(1,50));
    }

}
