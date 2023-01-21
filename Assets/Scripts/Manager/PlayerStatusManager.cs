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
    [SerializeField]
    private Weapon realSword;

    [SerializeField]
    private Image hpbar;

    [SerializeField]
    private Image expBar;

    [SerializeField]
    private Image mpbar;

    [SerializeField]
    private Animator anim;

    public PlayerController controller;

    // ����ġ�� ���ϰ� ������ġ�Ǹ� ����ġ�� 0���� ����� ������,����ġ�� ���� ��ƼŬ����
    public UnityAction<float> hpAction;
    public UnityAction<int> levelAction;
    public UnityAction<float> expAction;
    public UnityAction<float> mpAction;

    [SerializeField]
    public ParticleSystem particle;

    [SerializeField]
    private float maxMp;

    private float curMp;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private float curHp;

    [SerializeField]
    private int level;

    [SerializeField]
    private float maxExp;
    private float curexp;

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
    private void Update()
    {
        if (curexp == maxExp)
        { 
            Levelup(); 
        }

        if (curHp <= 0)
            Die();

        mpbar.fillAmount = curMp / maxMp;
        expBar.fillAmount = curexp / maxExp;    
        hpbar.fillAmount = curHp / maxHp;
    }

    public void ExpUp(float exp)
    {
        Exp += exp;
    }

    public void Die()
    {
        controller.rtsMove = false;
        anim.SetBool("Die",true);
    }

    public void Levelup()
    {
        particle.Play();
        Debug.Log("������! ������ 1��ŭ �ö�");
        Debug.Log("ü����" + maxHp +"��ŭ �����մϴ�");
        Debug.Log("����ġ�� "+ Exp + "��ŭ �����մϴ�" );
        Debug.Log("�������� "+ realSword.damage + "��ŭ �����մϴ�" );
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
        anim.SetTrigger("TakeHit");
    }

    public void UseMp(float Mp)
    {
        MP -= Mp;
    }
    
}