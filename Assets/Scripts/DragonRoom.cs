using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRoom : MonoBehaviour
{
    private RpgEnemy rpgEnemy;
    public GameObject bossRoom;

    private void Awake()
    {
        rpgEnemy = GetComponent<RpgEnemy>();
    }
    private void Start()
    {
        bossRoom.SetActive(false);
    }
    public void Update()
    {
        if (rpgEnemy.curHp <= 4999999)
            bossRoom.SetActive(true);
    }

}
