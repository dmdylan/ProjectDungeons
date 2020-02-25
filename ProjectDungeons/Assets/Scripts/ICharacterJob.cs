using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterJob 
{
    //Job Info
    string JobName { get; }
    string JobDescription { get; }
    string JobWeaponType { get; }
    string JobRole { get; }

    //Defensive Stats
    float Armor { get; }
    float Resist { get; }
    float Health { get; }
    float Perseverance { get; }

    //Offensive Stats
    float Power { get; }
    float Resource { get; }
    float ResourceRegen { get; }
    float CriticalChance { get; }
    float Haste { get; }
    float AttackPotency { get; }
}
