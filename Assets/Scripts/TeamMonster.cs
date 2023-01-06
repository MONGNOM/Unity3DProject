using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TeamMonster : MonoBehaviour
{
    private NavMeshAgent agent;

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
    [SerializeField]
    private int mineral;
    public Sprite icon;
    public bool attack;



    [SerializeField]
    private EnemyTower enemyTower;

    [SerializeField]
    public GameObject unitMarker;
    private Enemy target;

    private UnitMovement move;


    [SerializeField]
    public Vector3 destination;

    public LayerMask ground;

    public int Mineral { get { return mineral; } private set { mineral = value; } }

    private void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
        curhp = maxhp;
        move = GetComponent<UnitMovement>();
    }

    private void Start()
    {
        enemyTower = GameObject.FindGameObjectWithTag("EnemyTower").GetComponent<EnemyTower>();
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        UnitSelection.Instance.unitList.Add(this.gameObject);
        attack = true;
    }

   

    private void Update()
    {
        FindTarget();
        Die();
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);    
    }



    private void FindTarget()
    {
        if (attack)
        {
            target = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                target = colliders[i].GetComponent<Enemy>();
                if (null != target)
                {
                    gameObject.transform.LookAt(target.transform.position);
                    Attack();
                    agent.destination = target.transform.position;
                    break;
                }
              
            }
        }
        else
        {
            return;
        }
    }

    private void Attack()
    { 
        
    }

    private void TakeHit()
    {
        curhp -= target.damage;    
    }

    private void Die()
    {
        if (curhp <= 0) Destroy(gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy") TakeHit();
    }

}
