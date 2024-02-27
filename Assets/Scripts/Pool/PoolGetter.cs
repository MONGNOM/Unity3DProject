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
    public void NameGet(string get, Vector3 pos)
    {
        Debug.Log("222");
        Key = get;
        pool.NameGet(Key,pos);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("333");
            pool.NameGet("SwordWave",transform.position);
            
        }
    }
}
