using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFireBall : MonoBehaviour
{
    public GameObject fireBall;
    [SerializeField]
    public Transform attackMarine;
    public float makeFireTiem;
    public float deleteTime;
    public TeamMonster TeamMonster;
    public FireballShot ball;

    private void Awake()
    {
        TeamMonster = GetComponent<TeamMonster>();
    }

    public void MakeFireball()
    {
        makeFireTiem -= Time.deltaTime;
        if (makeFireTiem <= 0)
        {
            Instantiate(fireBall, attackMarine.transform.position, attackMarine.transform.rotation);
            makeFireTiem = 1.7f;

          
        }
    }
}
