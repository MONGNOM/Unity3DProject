using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using UnityEngine.UIElements;

enum playerstate { Normal, Battle }
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    playerstate state;

    private Animator anim;

    [SerializeField]
    private Rigidbody rb;

    [Header("Attack")]
    [SerializeField]
    private bool AttackGizmo;
    [SerializeField]
    private float attackRange;
    [SerializeField, Range(0f, 360f)]
    private float attackAngle;

    [Header("InterAction")]
    [SerializeField]
    private bool interActionGizmo;
    [SerializeField]
    private float interActionkRange;
    [SerializeField, Range(0f, 360f)]
    private float interActionAngle;


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

    public RpgEnemy rpgEnemy;

    [SerializeField]
    private GameObject damageText;

    [SerializeField]
    private Transform textTransform;

    public bool hpDown;

    public float hpdownTime;

    public UnityEvent swordwave;
    public GameObject sword;
    public GameObject startSwordWave;
    public GameObject endSwordWave;

    public PoolGetter pool;
    private void Awake()
    {
        gameObject.transform.position = new Vector3(28.39f, 5.06f, -57f);
        playerview = GetComponent<PlayerViewr>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        pool = FindObjectOfType<PoolGetter>();
        //minimap = GameObject.Find("MiniMap_Cam").GetComponent<MiniMapController>();
        //canvas = GameObject.Find("StarCraftCanvus").GetComponent<Canvas>();
    }

    private void Start()
    {
        hpDown = true;
        //gameObject.transform.position = new Vector3(28.39f, 5.06f, -57f);
        weapon.HideSword();
        weaponhouse.HideSword();
        rtsMove = true;
        playermove = true;
        state = playerstate.Normal;
        //rpgEnemy = GameObject.FindGameObjectWithTag("RpgEnemy").GetComponent<RpgEnemy>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown("0"))
        {
            PlayerStatusManager.Instance.Levelup();
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
                InterAction();
                break;
    
            case playerstate.Battle:
                Move();
                Jump(); 
                Attack();
                ChangeMode();
                InterAction();
                // 구르기 구현
                break;
        }

    }


    public void InterAction()
    {
        if (!Input.GetButtonDown("InterAction")) 
            return;

        // 1. 범위내에 있는가?
        Collider[] colliders = Physics.OverlapSphere(transform.position, interActionkRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;
            Vector3 rightDir = AngleToDir(transform.eulerAngles.y + interActionAngle * 0.5f);

            // 2. 각도내에 있는가?
            if (Vector3.Dot(transform.forward, dirToTarget) > Vector3.Dot(transform.forward, rightDir))
            {
                IInteractable target = colliders[i].GetComponent<IInteractable>();
                target?.InterAction(this);
              
            }
        }
    }

    public void TakeHit(float damage)
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
                {
                    colliders[i].gameObject.GetComponent<Enemy>().curhp -= realSword.damage;
                    //TakeDamage(realSword.damage);
                    GameObject hudText = Instantiate(damageText, textTransform);
                    hudText.transform.position = Camera.main.WorldToScreenPoint(colliders[i].gameObject.GetComponent<Enemy>().transform.position);
                }
                else if (colliders[i].gameObject.tag == "EnemyTower")
                {
                    colliders[i].gameObject.GetComponent<EnemyTower>().curhp -= realSword.damage;
                    //TakeDamage(realSword.damage);
                    GameObject hudText = Instantiate(damageText, textTransform);
                    hudText.transform.position = Camera.main.WorldToScreenPoint(colliders[i].gameObject.GetComponent<EnemyTower>().transform.position);
                }
                else if (colliders[i].gameObject.tag == "RpgEnemy")
                {
                    colliders[i].gameObject.GetComponent<RpgEnemy>().curHp -= realSword.damage;
                    //rpgEnemy.anim.SetTrigger("TakeHit");
                    GameObject hudText = Instantiate(damageText, textTransform);
                    hudText.transform.position = Camera.main.WorldToScreenPoint(colliders[i].gameObject.GetComponentInChildren<RpgEnemy>().transform.position);
                    //TakeDamage(realSword.damage);
                }
                else if (colliders[i].gameObject.tag == "RpgBoss")
                {
                    colliders[i].gameObject.GetComponentInChildren<RpgEnemy>().curHp -= realSword.damage;
                    GameObject hudText = Instantiate(damageText, textTransform);
                    hudText.transform.position = Camera.main.WorldToScreenPoint(colliders[i].gameObject.GetComponentInChildren<RpgEnemy>().transform.position);
                    rpgEnemy.anim.SetTrigger("TakeHit");
                }
            }
        }

        if (PlayerStatusManager.Instance.Level < 5)
            return;

        if (PlayerStatusManager.Instance.MP >= 0)
        {
            PlayerStatusManager.Instance.UseMp(100);
            Vector3 rotation = startSwordWave.transform.rotation.eulerAngles;
            rotation.z = weapon.transform.rotation.eulerAngles.z;
            pool.NameGet("SwordWave");
        }
        else
            return;
    }

    public void TakeDamage(float damage)
    {
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>();
        GameObject hudText = Instantiate(damageText, textTransform);
        hudText.transform.position = Camera.main.WorldToScreenPoint(rpgEnemy.transform.position);
        //hudText.GetComponent<DamageText>().damage = damage;
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
        // 점프가 이상하다
        if (!rtsMove) return;

        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (Physics.Raycast(transform.position, Vector2.down, out hit, 0.5f, LayerMask.GetMask("Ground")))
        //    {
        //        //땅에있다
        //        rb.AddForce(Vector3.up * jumpPower,ForceMode.Impulse);
        //        anim.SetBool("YSpeed", true);
        //    }
        //    else
        //    {
        //        rb.AddForce(Vector3.down * Gravity, ForceMode.Impulse);
        //        anim.SetBool("YSpeed", false);
        //        //땅에없다
        //    }

        //}

        RaycastHit hit;
        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector2.down, out hit, 1f, LayerMask.GetMask("Ground")))
        {
            SpeedY = JumpPower;
            anim.SetBool("Jump", true);
        }
        else if (!Physics.Raycast(transform.position, Vector2.down, out hit, 1f, LayerMask.GetMask("Ground")))
        {
           SpeedY += Gravity * Time.deltaTime;
            anim.SetBool("Jump", false);
        }

        controller.Move(Vector3.up * SpeedY * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);

            Vector3 rightDir = AngleToDir(transform.eulerAngles.y + attackAngle * 0.5f);
            Vector3 leftDir = AngleToDir(transform.eulerAngles.y - attackAngle * 0.5f);
            Debug.DrawRay(transform.position, rightDir * attackRange, Color.blue);
            Debug.DrawRay(transform.position, leftDir * attackRange, Color.blue);
            Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.red);
        }
        if (interActionGizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, interActionkRange);

            Vector3 rightDir = AngleToDir(transform.eulerAngles.y + interActionAngle * 0.5f);
            Vector3 leftDir = AngleToDir(transform.eulerAngles.y - interActionAngle * 0.5f);
            Debug.DrawRay(transform.position, rightDir * interActionkRange, Color.blue);
            Debug.DrawRay(transform.position, leftDir * interActionkRange, Color.blue);
            Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.red);
        }
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
    public IEnumerator NotHpDownTime()
    {
        yield return new WaitForSeconds(hpdownTime);
        hpDown = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hpDown)
            return;

        else if (other.tag == "thooth")
        {
            hpDown = false;
            StartCoroutine(NotHpDownTime());
            Dragonthooth thooth = other.GetComponent<Dragonthooth>();
            TakeHit(thooth.damage);
            Debug.Log(string.Format("{0}범인찾기이빨", gameObject));
        }
        else if (other.tag == "flame")
        {
            hpDown = false;
            StartCoroutine(NotHpDownTime());
            DragonFire flame = other.GetComponent<DragonFire>();
            TakeHit(flame.damage);
            Debug.Log(string.Format("{0}범인찾기불", gameObject));
        }
    }


}
