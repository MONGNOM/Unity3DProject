using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RpgEnemy : MonoBehaviour
{

    public NavMeshAgent agent;

    [SerializeField]
    public float maxHp;
    public float curHp;

    public Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        curHp = maxHp;
    }
    private void Update()
    {
        if (curHp <= 0)
            Die();
    }

    private void Die()
    {
        anim.SetBool("Die",true);
    }

}
