using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Base Stat", menuName = "Stats/Base Stats")]
public class BaseStats : ScriptableObject
{
    [SerializeField] private float _armor = 0;
    [SerializeField] private float _resist = 0;
    [SerializeField] private float _maxHealth = 0;
    [SerializeField] private float _perseverance = 0;
    [SerializeField] private float _power = 0;
    [SerializeField] private float _criticalChance = 0;
    [SerializeField] private float _haste = 0;
    [SerializeField] private float _attackPotency = 0;

    public float Armor => _armor;
    public float Resist => _resist;
    public float MaxHealth => _maxHealth;
    public float Perseverance => _perseverance;
    public float Power => _power;
    public float CriticalChance => _criticalChance;
    public float Haste => _haste;
    public float AttackPotency => _attackPotency;
}
