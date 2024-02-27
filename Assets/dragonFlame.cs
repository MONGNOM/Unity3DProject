using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dragonFlame : StateMachineBehaviour
{
    public DragonFire fire;

    public float firetime;
    private void Awake()
    {
        fire = FindObjectOfType<DragonFire>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        ParticleSystem particle = GameObject.Find("Flame").GetComponent<ParticleSystem>();
        particle.Play();
        if (firetime <= 0)
        {
            fire.gameObject.SetActive(true);
            firetime = 1;
        }
    }

   override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        firetime -= Time.deltaTime;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        ParticleSystem particle = GameObject.Find("Flame").GetComponent<ParticleSystem>();
        particle.Stop();
        fire.gameObject.SetActive(false);

    }


}
