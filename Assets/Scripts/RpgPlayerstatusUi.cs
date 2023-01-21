using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RpgPlayerstatusUi : MonoBehaviour
{
    

    [SerializeField]
    private TextMeshProUGUI hpValue;
    [SerializeField]
    private TextMeshProUGUI expValue;
    [SerializeField]
    private TextMeshProUGUI levelValue;
    [SerializeField]
    private TextMeshProUGUI mpValue;


    private void Start()
    {
        PlayerStatusManager.Instance.expAction += ChangeRpgExp;
        PlayerStatusManager.Instance.hpAction += ChangeRpgHp;
        PlayerStatusManager.Instance.levelAction += ChangeRpgLevel;
        PlayerStatusManager.Instance.mpAction += ChangeRpgMp;
    }
    private void Update()
    {
        ChangeRpgExp(PlayerStatusManager.Instance.Exp);
        ChangeRpgHp(PlayerStatusManager.Instance.HP);
        ChangeRpgLevel(PlayerStatusManager.Instance.Level);
        ChangeRpgMp(PlayerStatusManager.Instance.MP);
    }

    private void ChangeRpgLevel(int level)
    { 
        levelValue.text = level.ToString();
    }
    private void ChangeRpgHp(float hp)
    {
        hpValue.text = hp.ToString();

    }
    private void ChangeRpgExp(float exp)
    {
        expValue.text = exp.ToString();
    }
    private void ChangeRpgMp(float mp)
    {
        mpValue.text = mp.ToString();
    }
}
