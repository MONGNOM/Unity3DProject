using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fireball : MonoBehaviour
{
    public UnityEvent fireball;

    public TeamMonster monster;

    public Fireball(TeamMonster monster)
    { 
        this.monster = monster;
    }

    private void Update() 
    {
        if (monster.maekfireball )
        fireball?.Invoke();
    }
}
