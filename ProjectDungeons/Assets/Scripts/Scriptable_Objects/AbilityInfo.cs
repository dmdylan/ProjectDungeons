using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Physical, Magical }
public enum EffectType { None, Stun, Slow, Snare}

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public abstract class AbilityInfo : ScriptableObject
{
    [SerializeField] private string abilityName = "New Ability Name";
    [SerializeField] private string abilityToolTip = "New Ability Tooltip";
    [SerializeField] private float abilityCooldown = 0;
    [SerializeField] private float abilityBaseDamage = 0;
    [SerializeField] private float abilityScalingValue = 0;
    [SerializeField] private float abilityRange = 0;
    [SerializeField] private int levelRequirement = 1;
    [SerializeField] private DamageType abilityDamageType = DamageType.Physical;
    [SerializeField] private EffectType abilityEffectType = EffectType.None;
    [SerializeField] private float effectDuration = 0;
    [SerializeField] private Sprite icon = null;
    private Color abilityColor = new Color();

    public string AbilityName => abilityName;
    public string AbilityToolTip => abilityToolTip;
    public float AbilityCooldown => abilityCooldown;
    public float AbilityBaseDamage => abilityBaseDamage;
    public float AbilityScalingValue => abilityScalingValue;
    public float AbilityRange => abilityRange;
    public int LevelRequirement => levelRequirement;
    public DamageType AbilityDamageType => abilityDamageType;
    public EffectType AbilityEffectType => abilityEffectType;
    public float EffectDuration => effectDuration;
    public Sprite Icon => icon;
    public Color AbilityColor
    {
        get
        {
            if (AbilityDamageType.Equals(DamageType.Physical))
            { 
                abilityColor = Color.red;
            }
            else if (AbilityDamageType.Equals(DamageType.Magical))
            {
                abilityColor = Color.blue;
            }

            return abilityColor;
        }
    }

    public abstract void Initialize();
    public abstract void OnTriggerAbility();

}

