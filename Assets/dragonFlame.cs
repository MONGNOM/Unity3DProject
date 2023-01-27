using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonFlame : StateMachineBehaviour
{

   override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        ParticleSystem particle = GameObject.Find("Flame").GetComponent<ParticleSystem>();
        particle.Play();
    }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
       
   }

   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        ParticleSystem particle = GameObject.Find("Flame").GetComponent<ParticleSystem>();
        particle.Stop();
    }


}
