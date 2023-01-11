using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackmarine : MonoBehaviour,ICommandable
{
    public TeamMonster monster;
    public UnitMovement unit;

    public Attackmarine (TeamMonster monster, UnitMovement unit)
    {
        this.monster = monster;
        this.unit = unit;
    }

    public void Update()
    {
        monster.marine = true;
    }

    public void Execute()
    {
        MarineAttack();
    }

   

    public void MarineAttack()
    {
        monster.attack = true;
        monster.marine = true;
        
    }
}
