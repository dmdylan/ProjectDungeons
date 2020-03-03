using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BasePlayerClass
{
    BaseStats warriorBaseStats = Resources.Load("Assets/Scriptable Objects/WarriorBaseStats.asset") as BaseStats;

    public WarriorClass()
    {
        Class = "Warrior";
        Armor = warriorBaseStats.Armor;
        Resist = warriorBaseStats.Resist;
        MaxHealth = warriorBaseStats.MaxHealth;
        Perseverance = warriorBaseStats.Perseverance;
        Power = warriorBaseStats.Power;
        CriticalChance = warriorBaseStats.CriticalChance;
        Haste = warriorBaseStats.Haste;
        AttackPotency = warriorBaseStats.AttackPotency;
    }
}
