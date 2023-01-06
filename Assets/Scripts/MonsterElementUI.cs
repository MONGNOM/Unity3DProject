using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterElementUI : MonoBehaviour
{
    private TeamMonster monster;

    [SerializeField]
    private Button button;
    [SerializeField]
    private Image buttonImage;
    [SerializeField]
    private TextMeshProUGUI mineral;


    private void Start()
    {
        SpawnManager.Instance.OnChangeMineral += Refresh;

        Refresh(SpawnManager.Instance.Mineral);
        button.onClick.AddListener(Clicked);
        button.onClick.AddListener(Spawn);
    }

    public void SetMonster(TeamMonster monster)
    { 
        this.monster = monster;
        buttonImage.sprite = monster.icon;
        mineral.text = monster.Mineral.ToString();
    }

    public void Spawn()
    {
        SpawnManager.Instance.Spawn();
    }

    public void Clicked()
    {
        SpawnManager.Instance.ChangeSelectedMonster(monster);
    }

    public void Refresh(int mineral)
    {
        if (mineral >= monster.Mineral)
            button.interactable = true;
        else
            button.interactable = false;

    }

   
}
