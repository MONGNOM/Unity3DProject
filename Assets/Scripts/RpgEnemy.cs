using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RpgEnemy : MonoBehaviour
{

    public NavMeshAgent agent;

    private PlayerController controller;

    public string bossName;


    [SerializeField]
    private float attackRange;

    public float damage;


    [SerializeField]
    public float maxHp;
    public float curHp;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        curHp = maxHp;
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (curHp <= 0)
            Die();

        anim.SetFloat("curHp", curHp); // 보스 체력을 읽어주는 것 같은데 뭐지
    }

    public void OnAttackHit()
    {
        Collider[] colliders = Physics.OverlapSphere(anim.gameObject.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            controller = colliders[i].GetComponent<PlayerController>();
            if (null != controller)
            {
                anim.SetTrigger("Attack");
                PlayerStatusManager.Instance.TakeHit(damage);
                Debug.Log("플레이어를 공격함111");
            }
        }
    }

    public void Die()
    {
        anim.SetBool("Die",true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, attackRange);
    }
}
