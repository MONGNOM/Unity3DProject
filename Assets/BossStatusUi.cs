using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossStatusUi : SingleTon<BossStatusUi>
{
    public TextMeshProUGUI BossName;
    public Slider slider;
    public RpgEnemy rpg;

    public UnityEvent unityEvent;
   
    public void Start()
    {
    }

    private void Update()
    {
        rpg = GameObject.FindGameObjectWithTag("RpgBoss").GetComponent<RpgEnemy>();
        if (rpg != null)
            unityEvent?.Invoke();
        else
            return;
    }

    public void ChangeBossName()
    {
        BossName.text = rpg.ToString();
    }
}
