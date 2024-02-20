using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGetter : MonoBehaviour
{
    public PoolManager pool;
    string Key;

    private void Awake()
    {
        pool = FindObjectOfType<PoolManager>();
    }
    public void NameGet(string get)
    {
        Key = get;
        pool.NameGet(Key);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            pool.NameGet("SwordWave");
        }
    }
}
