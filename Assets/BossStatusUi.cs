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
        rpg = GameObject.FindWithTag("RpgBoss").GetComponentInChildren<RpgEnemy>();
        if (rpg != null)
            BossName.text = rpg.bossName;
        else
            return;
    }

    public void ChangeBossName()
    {
        if (rpg != null)
        {
            BossName.text = rpg.bossName;
        }
        else
        { 
            BossName.text = null;
        }
    }
}
