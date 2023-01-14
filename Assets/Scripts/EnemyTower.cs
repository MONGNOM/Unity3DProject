using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTower : MonoBehaviour
{
    [SerializeField]
    private int maxhp;

    [SerializeField]
    public int curhp;

    [SerializeField]
    private Slider hpbar;

    [SerializeField]
    private TeamMonster teamMonster;

    public FireballShot ball;

    public MeleeAttackMonster meleeattack;
    public RangedAttackMonster rangedAttack;

        
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
    private void TakeHit(int damage)
    {
        curhp -= damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "RangedAttack")
        {
            FireballShot fireball = collision.gameObject.GetComponent<FireballShot>();
            TakeHit(fireball.damage);
            Debug.Log("원거리 공격이 상대타워부시는중");
        }
        else if(collision.collider.tag == "TeamMonster")
        {
            MeleeAttackMonster meleeattack = collision.gameObject.GetComponent<MeleeAttackMonster>();
            TakeHit(meleeattack.damage);
            Debug.Log("근접공격이 상대타워부시는중");

        }
    }

}
