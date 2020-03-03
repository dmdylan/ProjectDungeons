using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    #region Player Variables
    //Character Info Variables
    private string _characterName = null;
    private float _currentExperience = 0;
    private int _playerLevel = 1;
    private BasePlayerClass _class = null;

    //Defensive Stat Variables
    private float _armor = 0;
    private float _resist = 0;
    private float _currentHealth = 0;
    private float _maxHealth = 0;
    private float _perseverance = 0;

    //Offensive Stat Variables
    private float _power = 0;
    private float _criticalChance = 0;
    private float _haste = 0;
    private float _attackPotency = 0;
    #endregion

    #region Player Properties
    //Character Info
    public string CharacterName { get { return _characterName; } set { _characterName = value; } }
    public float CurrentExperience { get { return _currentExperience; } set { _currentExperience = value; } }
    public int PlayerLevel { get { return _playerLevel; } set { _playerLevel = value; } }
    public BasePlayerClass Class { get { return _class; } }

    //Defensive Stats
    public float Armor { get { return _armor; } set { _armor = value; } }
    public float Resist { get { return _resist; } set { _resist = value; } }
    public float CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float Perseverance { get { return _perseverance; } set { _perseverance = value; } }

    //Offensive Stats
    public float Power { get { return _power; } set { _power = value; } }
    public float CriticalChance { get { return _criticalChance; } set { _criticalChance = value; } }
    public float Haste { get { return _haste; } set { _haste = value; } }
    public float AttackPotency { get { return _attackPotency; } set { _attackPotency = value; } }
    #endregion
}
