using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTower : MonoBehaviour
{
    public int Hp = 10;

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    { 
        if (Hp <= 0)
            Destroy(gameObject);
    }


}
