using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    #region Player Variables
    //Character Info Variables
    private string _characterName = null;
    private float _currentExperience = 0;
    private float _experienceNeeded = 0;
    private PlayerClass _class = null;

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

    #region Player Getter Properties
    //Character Info
    public string CharacterName { get { return _characterName; } }
    public float CurrentExperience { get { return _currentExperience; } }
    public float ExperienceNeeded { get { return _experienceNeeded; } }
    public PlayerClass Class { get { return _class; } }

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

    public PlayerCharacter()
    {

    }
}
