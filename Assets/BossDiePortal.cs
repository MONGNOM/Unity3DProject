using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class BossDiePortal : MonoBehaviour
{
    public UnityEvent unityEvent;

    public RpgEnemy rpgEnemy;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (tag == "RpgBoss" && rpgEnemy.curHp <= 0)
            unityEvent?.Invoke();
    }

    public void GoHome()
    {
        gameObject.SetActive(true);
    }

}
