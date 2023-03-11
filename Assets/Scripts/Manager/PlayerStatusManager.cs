using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerStatusManager : SingleTon<PlayerStatusManager>
{
    [Header("레벨")]
    [SerializeField]
    private int level;

    [Header("공격력")]
    [SerializeField]
    private float damage;

    [Header("체력")]
    [SerializeField]
    private float maxHp;
    private float curHp;



    [Header("마나")]
    [SerializeField]
    private float maxMp;
    private float curMp;
    
    [Header("경험치")]
    [SerializeField]
    private float maxExp;
  
    private float curexp;
    

    [Header("나머지")]

    [SerializeField]
    private Image mpbar;

    [SerializeField]
    private Image hpbar;
    [SerializeField]
    private Image expBar;
    
    [SerializeField]
    private Weapon realSword;

    [SerializeField]
    private Animator anim;

    public PlayerController controller;
    public StopButton stopButton;

    // 경험치량 정하고 일정수치되면 경험치를 0으로 만들고 레벨업,경험치량 증가 파티클생성
    public UnityAction<float> hpAction;
    public UnityAction<int> levelAction;
    public UnityAction<float> expAction;
    public UnityAction<float> mpAction;

    [SerializeField]
    public ParticleSystem particle;
    public swordwave sword;


    public float MP
    {
        get { return curMp; }
        private set { curMp = value; mpAction?.Invoke(curMp); }
    }

    public float HP
    {
        get { return curHp; }
        private set { curHp = value; hpAction?.Invoke(curHp); }
    }

    public float Exp
    {
        get { return curexp; }
        private set { curexp = value; expAction?.Invoke(curexp); }
    }

    public int Level
    {
        get { return level; }
        private set { level = value; levelAction?.Invoke(level); }
    }
    private void Awake()
    {
        curMp = maxMp;
        curexp = 0;
        curHp = maxHp;
    }
    private void Start()
    {
        stopButton = FindObjectOfType<StopButton>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (level >= 5)
                return;
                    Levelup();
        }

        if (curexp >= maxExp)
        { 
            Levelup(); 
        }

        if (curHp <= 0)
            Die();

        mpbar.fillAmount = curMp / maxMp;
        expBar.fillAmount = curexp / maxExp;    
        hpbar.fillAmount = curHp / maxHp;
        realSword.damage = damage;
    }

    public void ExpUp(float exp)
    {
        Exp += exp;
    }

    public void Die()
    {
        controller.rtsMove = false;
        anim.SetBool("Die",true);
        Time.timeScale = 0;
        stopButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Levelup()
    {
        particle.Play();
        Debug.Log("레벨업! 레벨이 1만큼 올라감");
        Debug.Log("체력이" + maxHp +"만큼 증가합니다");
        Debug.Log("경험치가 "+ Exp + "만큼 증가합니다" );
        Debug.Log("데미지가 "+ realSword.damage + "만큼 증가합니다" );
        Level += 1;
        maxExp += maxExp * 1.5f;
        maxHp += maxHp * 1.5f;
        maxMp += maxMp * 1.5f;
        curHp = maxHp;
        curMp = maxMp;
        curexp = 0;
        damage += damage * 1.7f;
    }

    public void TakeHit(float damage)
    {
        HP -= damage;
        anim.SetTrigger("TakeHit");
    }

    public void UseMp(float Mp)
    {
        MP -= Mp;
    }
    
}
