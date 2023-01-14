using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{

    [Header("Spec")]
    [SerializeField]
    public int maxhp;
    public int curhp;
    [SerializeField]
    public int damage;
    [SerializeField]
    private float range;
    [SerializeField]
    private float attackrange;
    [SerializeField]
    private float fireRagte;
    //[SerializeField]
    //private int mineral;

    public Animator anim;
    [SerializeField]
    public FireballShot ball;

    public MeleeAttackMonster meleeAttack;

    public RangedAttackMonster rangedAttack;

    [SerializeField]
    private Weapon realSwored;


    public int Damage { get { return damage; } private set { damage = value; } }

    [SerializeField]
    public MyTower tower;
    [SerializeField]
    public TeamMonster teamMonster;

    public NavMeshAgent agent;

    public PlayerController playerController;


    public Enemy(RangedAttackMonster rangedAttack)
    { 
        this.rangedAttack = rangedAttack;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        curhp = maxhp;
        anim = GetComponent<Animator>();


    }
    private void Start()
    {
        tower = GameObject.FindGameObjectWithTag("MyTower").GetComponent<MyTower>();
        agent.destination = tower.transform.position;
    }

 

    private void TakeHit(int damage)
    {
        curhp -= damage;
    }

   


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "RangedAttack")
        {
            FireballShot ball = collision.gameObject.GetComponent<FireballShot>();
            TakeHit(ball.damage);
        }
        else if (collision.collider.tag == "TeamMonster")
        {
            Debug.Log("근접공격한테 맞았다");
            MeleeAttackMonster attack = collision.gameObject.GetComponent<MeleeAttackMonster>();
            TakeHit(attack.damage);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position,range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(gameObject.transform.position,attackrange);

    }
}
