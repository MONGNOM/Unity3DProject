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
        monster = GameObject.FindGameObjectWithTag("RpgBoss").GetComponent<RpgEnemy>();
    }

    public void BossHPbar()
    { 
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
