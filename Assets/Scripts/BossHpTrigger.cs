using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHpTrigger : MonoBehaviour
{

    public UnityEvent unityEvent;
    private RpgEnemy monster;

    public Slider slider;
    private void Start()
    {
    }

    public void BossHPbar()
    { 
        monster = GameObject.FindGameObjectWithTag("RpgBoss").GetComponentInChildren<RpgEnemy>();
        monster = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>();
        //monster = GameObject.Find("RpgBoss (1)").GetComponent<RpgEnemy>();
        slider.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RpgBoss")
        {
            unityEvent?.Invoke();
        }
    }
}
