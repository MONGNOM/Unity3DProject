using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RpgAnimationEvent : MonoBehaviour
{

    public UnityEvent OnAttack;

    public void OnAttackHit()
    { 
        OnAttack?.Invoke();
        Debug.Log("Rpg적 공격 타이밍");
    
    }

}
