using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objectable : MonoBehaviour
{
    [SerializeField]
    private float poolTime;

    public PoolManager pool;
    void Start()
    {
        pool = FindObjectOfType<PoolManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(PoolDelete());
    }

    IEnumerator PoolDelete()
    {
        yield return new WaitForSeconds(poolTime);
        pool.Release(gameObject);
    }

}
