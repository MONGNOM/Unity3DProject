using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

enum playerstate { Normal, Battle }
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    playerstate state;

    private Animator anim;

   

    [SerializeField]
    private float attackRange;
    [SerializeField, Range(0f, 360f)]
    private float attackAngle;

    [SerializeField]
    private float movespeed;

    [SerializeField]
    private float JumpPower;

    [SerializeField]
    private float Gravity;

    private PlayerViewr playerview;

    private float SpeedY;
    private CharacterController controller;

    public bool playermove;

    public bool rtsMove;

    [SerializeField]
    private float changeTime;

    [SerializeField]
    private WeaponHand weapon;

    [SerializeField]
    private WeaponHouse weaponhouse;

    public bool playerBattle;

    public MiniMapController minimap;

    public Weapon realSword;

    public EnemyTower enemyTower;

 


    


    private void Awake()
    {
        playerview = GetComponent<PlayerViewr>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        //minimap = GameObject.Find("MiniMap_Cam").GetComponent<MiniMapController>();
        //canvas = GameObject.Find("StarCraftCanvus").GetComponent<Canvas>();
    }

    private void Start()
    {
        gameObject.transform.position = new Vector3(28.39f, 5.06f, -57f);
        weapon.HideSword();
        weaponhouse.HideSword();
        rtsMove = true;
        playermove = true;
        state = playerstate.Normal;
    }
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            PlayerStatusManager.Instance.TakeHit(10);
        }
        else if (Input.GetKeyDown("2"))
        {
            PlayerStatusManager.Instance.Levelup(1);
        }
        else if (Input.GetKeyDown("3"))
        {
            PlayerStatusManager.Instance.ExpUp(5);
        }


        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
            playermove = true;

        switch (state)
        {
            case playerstate.Normal:
                Move();
                ChangeMode();
                Jump();
                break;
    
            case playerstate.Battle:
                Move();
                Jump(); 
                Attack();
                ChangeMode();
                // 구르기 구현
                break;
        }

    }

    public void TakeHit(int damage)
    {
        PlayerStatusManager.Instance.TakeHit(damage);
    }

    public void ChangeMode()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (state == playerstate.Normal)
        {
            state = playerstate.Battle;
            anim.SetLayerWeight(1, 1f);
            anim.SetTrigger("ChangeForm");
            anim.SetLayerWeight(2, 0f);
            playermove = false;
            changeTime = 1.5f;
            playerBattle = true;
        }
        else if (state == playerstate.Battle)
        {
            state = playerstate.Normal;
            anim.SetLayerWeight(1, 0f);
            anim.SetTrigger("ChangeForm");
            anim.SetLayerWeight(2, 0f);
            playermove = false;
            changeTime = 1.5f;
            playerBattle = false;
        }
    }

    public void Attack()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        anim.SetTrigger("Attack");
   
    }

    public void OnAttackHit()
    {
        // 1. 범위내에 있는가?
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;
            Vector3 rightDir = AngleToDir(transform.eulerAngles.y + attackAngle * 0.5f);

            // 2. 각도내에 있는가?
            if (Vector3.Dot(transform.forward, dirToTarget) > Vector3.Dot(transform.forward, rightDir))
            {
                if (colliders[i].gameObject.tag == "Enemy") // 나중에 데미저블 컴포넌트 가지고 있는 애들만 데미지 주는 걸로 구현
                    colliders[i].gameObject.GetComponent<Enemy>().curhp -= realSword.damage;
                else if(colliders[i].gameObject.tag == "EnemyTower")
                    colliders[i].gameObject.GetComponent<EnemyTower>().curhp -= realSword.damage;
            }
        }

    }

    public void OnAttackStart()
    {
        weapon.EnableWeapon();
    }

    public void OnAttackEnd()
    {
        weapon.DisableWeapon();
    }

    public void Move()
    {
        if (!playermove) return;

        if (!rtsMove) return;

        if (playerview.playerView) // 1인칭 이동 및 시점
        {
            controller.Move(transform.right * Input.GetAxis("Horizontal") * movespeed * Time.deltaTime);
            controller.Move(transform.forward * Input.GetAxis("Vertical") * movespeed * Time.deltaTime);
        }
        else                       // 3인칭 이동 및 시점
        {
            Vector3 forwardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
            Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;

            Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");


            anim.SetFloat("XInput", Input.GetAxis("Horizontal"));
            anim.SetFloat("YInput", Input.GetAxis("Vertical"));

            if (moveInput.sqrMagnitude > 1) moveInput.Normalize();


            Vector3 moveVec = forwardVec * moveInput.z + rightVec * moveInput.x;

            controller.Move(moveVec * movespeed * Time.deltaTime);

            if (moveVec.sqrMagnitude != 0) transform.forward = Vector3.Lerp(transform.forward, moveVec, 0.8f);
        }
    }
    public void Jump()
    {
        if (!rtsMove) return;

        anim.SetFloat("YSpeed", SpeedY);

        if (Input.GetButtonDown("Jump")) SpeedY = JumpPower;
        else if (controller.isGrounded) SpeedY = 0;
        else SpeedY += Gravity * Time.deltaTime;

        controller.Move(Vector3.up * SpeedY * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + attackAngle * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - attackAngle * 0.5f);
        Debug.DrawRay(transform.position, rightDir * attackRange, Color.blue);
        Debug.DrawRay(transform.position, leftDir * attackRange, Color.blue);

    }

    private Vector3 AngleToDir(float angle)
    {
        float raidan = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(raidan), 0, Mathf.Cos(raidan));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        { 
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        TakeHit(enemy.damage);
        }
    }
}
