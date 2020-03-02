using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerClass : MonoBehaviour
{
    public string Class { get; set; }
    public float Armor { get; set; }
    public float Resist { get; set; }
    public float MaxHealth { get; set; }
    public float Perseverance { get; set; }
    public float Power { get; set; }
    public float CriticalChance { get; set; }
    public float Haste { get; set; }
    public float AttackPotency { get; set; }
}
