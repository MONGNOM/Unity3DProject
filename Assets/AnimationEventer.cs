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
        Debug.Log("����Ÿ�̹�");
        onAttackHit?.Invoke();
        particle.Play();
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
