using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrigger : MonoBehaviour
{
    public RpgEnemy rpgEnemy;
    public float damage;
    private void Awake()
    {
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>(); // �����Ҷ��� �¿��� ��
    }
    private void Start()
    {
        damage = rpgEnemy.damage;
    }
    private void OnParticleTrigger()
    {
        if (tag == "Player")
        {
            // �÷��̾� �Ǳ��
            Debug.Log("�Ǳ���");
        }
    }

}
