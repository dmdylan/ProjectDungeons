using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageClass : BasePlayerClass
{
    
    //BaseStats mageBaseStats = Resources.Load("Assets/Scriptable Objects/MageBaseStats.asset") as BaseStats;

    public MageClass()
    {
        Class = "Mage";
        Armor = 10;
        Resist = 20;
        MaxHealth = 75;
        Perseverance = 5;
        Power = 20;
        CriticalChance = 15;
        Haste = 20;
        AttackPotency = 10;
    }
}
