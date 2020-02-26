using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    #region Player Variables
    //Character Info Variables
    private string _characterName;
    private float _currentExperience;
    private float _experienceNeeded;

    //Defensive Stat Variables
    private float _armor;
    private float _resist;
    private float _currentHealth;
    private float _maxHealth;
    private float _perseverance;

    //Offensive Stat Variables
    private float _power;
    private float _criticalChance;
    private float _haste;
    private float _attackPotency;
    #endregion

    #region Player Properties
    //Character Info
    public string CharacterName { get { return _characterName; } }
    public float CurrentExperience { get { return _currentExperience; } }
    public float ExperienceNeeded { get { return _experienceNeeded; } }

    //Defensive Stats
    public float Armor { get { return _armor; } }
    public float Resist { get { return _resist; } }
    public float CurrentHealth { get { return _currentHealth; } }
    public float MaxHealth { get { return _maxHealth; } }
    public float Perseverance { get { return _perseverance; } }

    //Offensive Stats
    public float Power { get { return _power; } }
    public float CriticalChance { get { return _criticalChance; } }
    public float Haste { get { return _haste; } }
    public float AttackPotency { get { return _attackPotency; } }
    #endregion
}
