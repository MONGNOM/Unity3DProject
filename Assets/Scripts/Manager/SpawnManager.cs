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
                Debug.Log("미네랄이 부족합니다.");
                return;
            }

            Debug.Log("몬스터를 소환합니다.");
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
        Debug.Log(mineral+"을 흭득했습니다.");
    }

    public void LevelMineral()
    {
        Mineral -= myTower.Mineral;
    }
}
