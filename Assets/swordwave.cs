using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class swordwave : MonoBehaviour
{
    public float wavedelete;
    public float waveSpeed;
    public float damage;
    public PlayerController playerController;
    public Weapon weapon;
    public RpgEnemy rpgEnemy;
    [SerializeField]
    private GameObject damageText;
    public WaveStartPoint startSwordWave;
    public Enemy enemy;

    [SerializeField]
    private Transform textTransform;
        
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        enemy = FindObjectOfType<Enemy>();
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>();
        startSwordWave = FindObjectOfType<WaveStartPoint>();
        weapon = FindObjectOfType<Weapon>();
        Vector3 rotation = startSwordWave.transform.rotation.eulerAngles;
        rotation.z = weapon.transform.rotation.eulerAngles.z;
        gameObject.transform.rotation = Quaternion.Euler(rotation);
        damage = weapon.damage;
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * waveSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RpgBoss")
        {
            Debug.Log("검기데미지들어옴");
            rpgEnemy.curHp -= damage;
            playerController.TakeDamage(damage);

        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy.curhp -= damage;
            playerController.TakeDamage(damage);
           
        }
    }
}
