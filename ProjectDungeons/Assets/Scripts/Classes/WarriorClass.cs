using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BasePlayerClass
{
    public BaseStats warriorBaseStats;

    public WarriorClass()
    {
        Armor = warriorBaseStats.Armor;
        Class = "Warrior";
        Resist = warriorBaseStats.Resist;
        MaxHealth = warriorBaseStats.MaxHealth;
        Perseverance = warriorBaseStats.Perseverance;
        Power = warriorBaseStats.Power;
        CriticalChance = warriorBaseStats.CriticalChance;
        Haste = warriorBaseStats.Haste;
        AttackPotency = warriorBaseStats.AttackPotency;
    }
}
