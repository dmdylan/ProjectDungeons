using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageType { Physical, Magical }

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AbilityInfo : ScriptableObject
{

    [SerializeField] private string abilityName = "New Ability Name";
    [SerializeField] private string abilityToolTip = "New Ability Tooltip";
    [SerializeField] private float abilityCooldown = 0;
    [SerializeField] private float abilityBaseDamage = 0;
    [SerializeField] private float abilityScalingValue = 0;
    [SerializeField] private int levelRequirement = 1;
    [SerializeField] private DamageType abilityDamageType;
    [SerializeField] private Sprite icon = null;
    private Color abilityColor = new Color();

    public string AbilityName => abilityName;
    public string AbilityToolTip => abilityToolTip;
    public float AbilityCooldown => abilityCooldown;
    public float AbilityBaseDamage => abilityBaseDamage;
    public float AbilityScalingValue => abilityScalingValue;
    public int LevelRequirement => levelRequirement;
    public DamageType AbilityDamageType => abilityDamageType;
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
}

