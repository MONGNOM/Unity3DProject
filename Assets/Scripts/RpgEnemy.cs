using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RpgEnemy : MonoBehaviour
{

    public NavMeshAgent agent;

    private PlayerController controller;

    public string bossName;


    [SerializeField]
    private float attackRange;

    [SerializeField]
    private float damage;


    [SerializeField]
    public float maxHp;
    public float curHp;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        curHp = maxHp;
    }
    private void Start()
    {
    }
    private void Update()
    {
        if (curHp <= 0)
            Die();
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
