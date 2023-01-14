using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class SpawnManager : SingleTon<SpawnManager>
{
    [Header("Spawn")]

    private TeamMonster selectedMonster;

    [SerializeField]
    private Transform point;

    private LevelUpButton button;

    [SerializeField]
    private MyTower myTower;

    [SerializeField]
    private int mineral;

    public UnityAction<int> OnChangeMineral;

    public TeamMonster SeletedMonster
    { 
        get { return selectedMonster; }
        private set { selectedMonster = value; }
    }

    public int Mineral
    {
        get { return mineral; }
        private set { mineral = value; OnChangeMineral?.Invoke(mineral); }
    }

    private void Start()
    {
        point = GameObject.Find("SpawnPoint").GetComponent<Transform>();
        myTower = GameObject.Find("MyTower").GetComponent<MyTower>();


    }
    //private void Update()
    //{
    //    point = GameObject.Find("SpawnPoint").GetComponent<Transform>();
    //    myTower = GameObject.Find("MyTower").GetComponent<MyTower>();
        
    //}

    public void Spawn()
    {
            if (selectedMonster.Mineral > Mineral)
            {
                Debug.Log("�̳׶��� �����մϴ�.");
                return;
            }

            Debug.Log("���͸� ��ȯ�մϴ�.");
            Instantiate(selectedMonster, point.transform.position, Quaternion.Euler(0, 0, 0));
            Mineral -= selectedMonster.Mineral;
    }


    public void ChangeSelectedMonster(TeamMonster monster)
    {
        selectedMonster = monster;
    }

    public void GainMineral(int mineral)
    {
        Mineral += mineral;
        Debug.Log(mineral+"�� ŉ���߽��ϴ�.");
    }

    public void LevelMineral()
    {
        Mineral -= myTower.Mineral;
    }
}
