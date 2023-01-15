using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerStatusManager : SingleTon<PlayerStatusManager>
{
    public UnityAction<int> hpAction;
    public UnityAction<int> levelAction;
    public UnityAction<int> expAction;

    [SerializeField]
    private int maxHp;

    [SerializeField]
    private int curHp;

    [SerializeField]
    private int level;

    [SerializeField]
    private int exp;
    public int HP
    {
        get { return curHp; }
        private set { curHp = value; hpAction?.Invoke(curHp); }
    }

    public int Exp
    {
        get { return exp; }
        private set { exp = value; expAction?.Invoke(exp); }
    }

    public int Level
    {
        get { return level; }
        private set { level = value; levelAction?.Invoke(level); }
    }
    private void Awake()
    {
        curHp = maxHp;
    }

    public void ExpUp(int exp)
    {
        Exp += exp;
    }

    public void Levelup(int level)
    {
        Level += level;
    }

    public void TakeHit(int damage)
    {
        HP -= damage;
    }
}
