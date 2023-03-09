using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public RpgEnemy rpgEnemy;
    public float damage;
    private void Awake()
    {
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>(); // 공격할때만 온오프 ㄱ
    }
    private void Start()
    {
        damage = rpgEnemy.damage;
    }
    private void OnParticleTrigger()
    {
        if (tag == "Player")
        {
            // 플레이어 피깎기
            Debug.Log("피깍임");
        }
    }

}
