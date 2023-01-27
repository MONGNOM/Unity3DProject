using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelectUI : MonoBehaviour
{
    [SerializeField]
    private MonsterElementUI monsterElement;

    [SerializeField]
    private List<TeamMonster> monsters;


    private void Start()
    {
        for (int i = 0; i < monsters.Count; i++)
        { 
            MonsterElementUI monster = Instantiate(monsterElement, transform);
            monster.SetMonster(monsters[i]);
        }
    }
}
