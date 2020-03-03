using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageClass : BasePlayerClass
{
    BaseStats mageBaseStats = Resources.Load("Assets/Scriptable Objects/MageBaseStats.asset") as BaseStats;

    public MageClass()
    {
        Class = "Mage";
        Armor = mageBaseStats.Armor;
        Resist = mageBaseStats.Resist;
        MaxHealth = mageBaseStats.MaxHealth;
        Perseverance = mageBaseStats.Perseverance;
        Power = mageBaseStats.Power;
        CriticalChance = mageBaseStats.CriticalChance;
        Haste = mageBaseStats.Haste;
        AttackPotency = mageBaseStats.AttackPotency;
    }
}
