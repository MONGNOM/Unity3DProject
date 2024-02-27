using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : StateMachineBehaviour
{
    public TrailRenderer trail;
    
    private void Awake()
    {
        trail = FindObjectOfType<TrailRenderer>();
        
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        trail.emitting = true;
        animator.SetBool("boolAttack", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        trail.emitting = false;
        animator.SetBool("boolAttack", false);
    }

}
