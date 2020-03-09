using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BasePlayerClass
{
    //BaseStats warriorBaseStats = Resources.Load("Assets/Scriptable Objects/WarriorBaseStats.asset") as BaseStats;

    public WarriorClass()
    {
        Class = "Warrior";
        Armor = 20;
        Resist = 15;
        MaxHealth = 100;
        Perseverance = 10;
        Power = 20;
        CriticalChance = 5;
        Haste = 10;
        AttackPotency = 10;
    }
}
