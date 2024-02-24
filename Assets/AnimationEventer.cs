using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventer : MonoBehaviour
{
    public UnityEvent onAttackStart;
    public UnityEvent onAttackEnd;
    public UnityEvent onAttackHit;

    [SerializeField ]
    private ParticleSystem particle;

    public void AttackHit()
    {
        onAttackHit?.Invoke();
        Debug.Log("����Ÿ�̹�");
}
    public void OnAttackStart()
    {
        onAttackStart?.Invoke();
    }
    public void OnAttackEnd()
    {
        onAttackEnd?.Invoke();

    }
}
