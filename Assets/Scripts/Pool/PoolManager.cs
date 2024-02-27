using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public Dictionary<string, Stack<GameObject>> poolDic;
    public List<Poolable> poolprefab;
    private void Awake()
    {
        poolDic = new Dictionary<string, Stack<GameObject>>();
    }

    private void Start()
    {
        CreatePool();
    }

    public void CreatePool()
    {
        for (int i = 0; i < poolprefab.Count; i++)
        {
            Stack<GameObject> stack = new Stack<GameObject>();
            for (int j = 0; j < poolprefab[i].Count; j++)
            {
                GameObject instance = Instantiate(poolprefab[i].prefab);
                instance.SetActive(false);
                instance.gameObject.name = poolprefab[i].prefab.name;
                instance.transform.parent = poolprefab[i].Container;
                stack.Push(instance);
            }
            poolDic.Add(poolprefab[i].prefab.name, stack);
        }
    }

    public GameObject NameGet(string name,Vector3 pos)
    {
        Stack<GameObject> stack = poolDic[name];
        if (stack.Count > 0)
        {
            Debug.Log("111");
            GameObject instance = stack.Pop();
            instance.gameObject.SetActive(true);
            instance.transform.parent = null;
            instance.transform.position = pos;
            return instance;
        }
        else 
        {
            return null;
        }
    }

    public void Release(GameObject instance)
    {
        Stack<GameObject> stack = poolDic[instance.name];
        Poolable poolable = poolprefab.Find((x) => instance.name == x.Container.name);
        instance.SetActive(false);
        instance.transform.parent = poolable.Container;
        stack.Push(instance);

    }

    [Serializable]
    public struct Poolable
    {
        public GameObject prefab;
        public int Count;
        public Transform Container;
    }

}
