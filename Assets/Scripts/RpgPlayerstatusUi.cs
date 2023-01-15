using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RpgPlayerstatusUi : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI hpValue;
    [SerializeField]
    private TextMeshProUGUI expValue;
    [SerializeField]
    private TextMeshProUGUI levelValue;


    private void Start()
    {


        PlayerStatusManager.Instance.expAction += ChangeRpgExp;
        PlayerStatusManager.Instance.hpAction += ChangeRpgHp;
        PlayerStatusManager.Instance.levelAction += ChangeRpgLevel;

        ChangeRpgExp(PlayerStatusManager.Instance.Exp);
        ChangeRpgHp(PlayerStatusManager.Instance.HP);
        ChangeRpgLevel(PlayerStatusManager.Instance.Level);
    }
    

    private void ChangeRpgLevel(int level)
    { 
        levelValue.text = level.ToString();
    }
    private void ChangeRpgHp(int hp)
    {
        hpValue.text = hp.ToString();

    }
    private void ChangeRpgExp(int exp)
    {
        expValue.text = exp.ToString();
    }
}
