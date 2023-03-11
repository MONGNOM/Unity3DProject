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

    [SerializeField]
    private Transform textTransform;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        weapon = FindObjectOfType<Weapon>();
        rpgEnemy = GameObject.Find("RedDragon").GetComponentInChildren<RpgEnemy>();
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
    }
}
