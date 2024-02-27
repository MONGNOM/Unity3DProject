using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragontoothAttack : StateMachineBehaviour
{
    public Dragonthooth tooth;
    private void Awake()
    {
        tooth = FindObjectOfType<Dragonthooth>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tooth.gameObject.SetActive(true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tooth.gameObject.SetActive(false);
    }


}
