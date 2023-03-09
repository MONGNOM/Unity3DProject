using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonthooth : MonoBehaviour
{
    public RpgEnemy rpgEnemy;
    public float damage;

    private void Awake()
    {
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>(); // �����Ҷ��� �¿��� ��
    }

    void Start()
    {
        gameObject.SetActive(false);
        damage = rpgEnemy.damage;     
    }


}
