using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{

    [SerializeField]
    private Button button;
    [SerializeField]
    private MyTower tower;

    private SpawnManager spawnManager;
   

    void Start()
    {
        button.onClick.AddListener(Levelup);
    }

  

    public void Levelup()
    {
        if (SpawnManager.Instance.Mineral < tower.Mineral)
            return;

        WaveManager.Instance.LevelUp(1);
        SpawnManager.Instance.LevelMineral();
    }
}
