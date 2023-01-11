using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour
{
    [SerializeField]
    private int maxhp;
    private int curhp;

    [SerializeField]
    private Slider hpbar;

    [SerializeField]
    private TeamMonster teamMonster;



    private void Start()
    {
        curhp = maxhp;
        //teamMonster = GameObject.FindGameObjectWithTag("TeamMonster").GetComponent<TeamMonster>();

    }

    private void Update()
    {
        HpDown();
        GameOver();
    }
    private void HpDown()
    {
        hpbar.maxValue = maxhp;
        hpbar.value = curhp;
    }

    private void GameOver()
    {
        if (curhp <= 0)
        { 
            Time.timeScale = 0; 
            Destroy(gameObject);
        }
    }
    private void TakeHit()
    {
        curhp -= teamMonster.damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
            Debug.Log("�츮�� ���Ͱ� ��� Ÿ���� �����ϰ� �ִ�.");
            TakeHit();
    }

}
