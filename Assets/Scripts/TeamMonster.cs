using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TeamMonster : MonoBehaviour
{
    public NavMeshAgent agent;

    [Header("Spec")]
    [SerializeField]
    public int maxhp;
    public int curhp;
    [SerializeField]
    private int mineral;
    public Sprite icon;
    public bool attack;


    public Animator anim;

    [SerializeField]
    private float dieTime;

    [SerializeField]
    public GameObject unitMarker;

    public UnitMovement move;

    protected MakeFireBall fireball;

    [SerializeField]
    public Vector3 destination;

    public LayerMask ground;

    public bool die;

    public Enemy target;

    public bool Takehit;
    public UnitMovement unit;

    public int Mineral { get { return mineral; } private set { mineral = value; } }

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        move = GetComponent<UnitMovement>();
        curhp = maxhp;
    }

    private void Start()
    {
        attack =  true;
        die = false;
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    protected void Update()
    {
        if (curhp <= 0)
        {
            Die();
        }
    }

    private void OnDestroy()
    {
        UnitSelection.Instance.unitList.Remove(this.gameObject);
    }

    public void TakeHit(int damage)
    {
        Takehit = true;
        curhp -= damage;
        anim.SetTrigger("TakeHit");
    }

    protected void Die()
    {
            Debug.Log("몬스터가 죽었따");
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            TakeHit(enemy.Damage);
        }
    }

  
}
