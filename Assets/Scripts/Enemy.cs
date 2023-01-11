using Cinemachine;
using System.Collections;
using System.Collections.Generic;
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
    private float fireRagte;
    //[SerializeField]
    //private int mineral;

    public FireballShot ball;

    private WaveManager waveManager;

    private TeamMonster target;

    public int Damage { get { return damage; } private set { damage = value; } }

    [SerializeField]
    private MyTower tower;

    private NavMeshAgent agent;

    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        curhp = maxhp;

    }

    public void Start()
    {
        tower = GameObject.FindGameObjectWithTag("MyTower").GetComponent<MyTower>();
        //target = GameObject.FindGameObjectWithTag("TeamMonster").GetComponent<TeamMonster>();

    }

    private void Update()
    {
        FindTarget();
        Die();
    }

    private void FindTarget()
    {
        target = null;
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            target = colliders[i].GetComponent<TeamMonster>();
            if (null != target)
            {
                gameObject.transform.LookAt(target.transform.position);
                agent.destination = target.transform.position;
                break;
            }
            else
            {
                agent.destination = tower.transform.position;
            }
        }
    }
    private void TakeHit()
    {
        if (ball)
        curhp -= ball.damage;
        else
        curhp -= target.damage;
    }

    private void Die()
    {
        if (curhp <= 0)
        {
            SpawnManager.Instance.GainMineral(10);
            Destroy(gameObject);
        }
    }
    private void Attack()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "TeamMonster")
            TakeHit();
    }


}
