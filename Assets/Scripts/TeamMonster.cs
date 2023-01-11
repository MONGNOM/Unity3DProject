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

    private Animator anim;

    [SerializeField]
    private float dieTime;

    [SerializeField]
    private EnemyTower enemyTower;

    [SerializeField]
    public GameObject unitMarker;
    private Enemy target;

    private UnitMovement move;

    public MakeFireBall fireball;

    [SerializeField]
    public Vector3 destination;

    public LayerMask ground;

    public bool die;

    public bool marine;

    public bool maekfireball;

    public bool Takehit;

    public FireballShot ball;

    public int Mineral { get { return mineral; } private set { mineral = value; } }

    private void Awake()
    {
        
        anim = GetComponent<Animator>();
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
        die = false;
        maekfireball = false;

    }



    private void Update()
    {
        Die();

        if (curhp > 0)
        {
            FindTarget();
        }
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);    
    }



    private void FindTarget()
    {
        maekfireball = false;
        if (attack)
        {
            target = null;
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);
            for (int i = 0; i < colliders.Length; i++)
            {
                target = colliders[i].GetComponent<Enemy>();
                if (null != target && !marine)
                {
                    Attack();
                    gameObject.transform.LookAt(target.transform.position);
                    agent.destination = target.transform.position;
                    break;
                }
                else if (null != target && marine)
                {

                    agent.isStopped = true;
                    Takehit = false;
                    maekfireball = true;
                    Attack();
                    gameObject.transform.forward = target.transform.position;
                    gameObject.transform.LookAt(target.transform.position);
                    break;
                }

            }
        }
        else
            return;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void TakeHit()
    {
        Takehit = true;
        curhp -= target.damage;
        anim.SetTrigger("TakeHit");
    }

    private void Die()
    {
        if (curhp <= 0)
        {
            dieTime += Time.deltaTime;
            anim.SetBool("Die",true);
            die = true;
            attack = false;
            agent.speed = 0;

            if (dieTime >= 1.5f)
            {
                Destroy(gameObject);
            }
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Enemy") TakeHit();
    }

}
