using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RpgOrcDie : StateMachineBehaviour
{
    public RpgEnemy rpgenemy;
    [SerializeField]
    private float dieTime;

    [SerializeField]
    public int monsterexp;

    [SerializeField]
    private BoxCollider box;

    [SerializeField]
    private int undermineral;

    [SerializeField]
    private int overmineral;



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Die", false);
        rpgenemy = animator.GetComponent<RpgEnemy>();
        rpgenemy.agent.velocity = Vector3.zero;
        box = animator.GetComponent<BoxCollider>();
        box.enabled = false;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dieTime += Time.deltaTime;
        if (dieTime >= 1.5f)
        {
            Destroy(animator.gameObject);
            PlayerStatusManager.Instance.ExpUp(monsterexp);
            Debug.Log(monsterexp + "����ġ�� ����ϴ�");
            SpawnManager.Instance.GainMineral(Random.Range(undermineral,overmineral));
            Debug.Log(monsterexp + "��ȭ�� ����ϴ�.");
        }
        
        Debug.Log("������ ��");
        ParticleSystem particle = GameObject.Find("GoHome").GetComponent<ParticleSystem>();
        BoxCollider box = GameObject.Find("GoHome").GetComponent<BoxCollider>();
        particle.Play();
        box.enabled = true;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ����ġ �ý����� �Ʊ� ���ͷ� ���⼭�� �Ʊ����ͷ� �ְ� ���� rpg���� ����ġ ����

    }
}
