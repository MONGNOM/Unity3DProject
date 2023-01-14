using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireball : MonoBehaviour
{
    public UnityEvent fireball;

    public RangedAttackMonster rangedAttack;

    private void Awake()
    {
        rangedAttack = GetComponent<RangedAttackMonster>();
    }
    public Fireball(RangedAttackMonster rangedAttack)
    { 
        this.rangedAttack = rangedAttack;
    }

    private void Update() 
    {
        if (rangedAttack.maekfireball)
        fireball?.Invoke();
    }
}
