using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerStatusManager : SingleTon<PlayerStatusManager>
{
    [SerializeField]
    private Weapon realSword;

    [SerializeField]
    private Image hpbar;

    [SerializeField]
    private Image expBar;

    // 경험치량 정하고 일정수치되면 경험치를 0으로 만들고 레벨업,경험치량 증가 파티클생성
    public UnityAction<float> hpAction;
    public UnityAction<int> levelAction;
    public UnityAction<float> expAction;

    [SerializeField]
    public ParticleSystem particle;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private float curHp;

    [SerializeField]
    private int level;

    [SerializeField]
    private float maxExp;
    private float curexp;

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
        curexp = 0;
        curHp = maxHp;
    }
    private void Update()
    {
        if (curexp == maxExp)
        { 
            Levelup(); 
        }

        expBar.fillAmount = curexp / maxExp;    
        hpbar.fillAmount = curHp / maxHp;
    }

    public void ExpUp(float exp)
    {
        Exp += exp;
    }

    public void Levelup()
    {
        particle.Play();
        Debug.Log("레벨업! 레벨이 1만큼 올라감");
        Debug.Log("체력이" + maxHp +"만큼 증가합니다");
        Debug.Log("경험치가 "+ Exp + "만큼 증가합니다" );
        Debug.Log("데미지가 "+ realSword.damage + "만큼 증가합니다" );
        Level += 1;
        maxExp += maxExp * 2;
        maxHp += maxHp * 2;
        curHp = maxHp;
        curexp = 0;
        realSword.damage = realSword.damage * 1.3f;
    }

    public void TakeHit(float damage)
    {
        HP -= damage;
    }

    
}
