using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat 
{
    public float baseValue;

    public float Value
    {
        get
        {
            if (isDirty)
            {
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    private bool isDirty = true;
    private float _value;

    private readonly List<StatModifier> statModifiers;

    public CharacterStat(float baseValue)
    {
        this.baseValue = baseValue;
        statModifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if(a.order < b.order)
            return -1; 
        else if (a.order > b.order)       
            return 1;       
        return 0;
    }
    
    public bool RemoveModifier(StatModifier mod)
    {
        isDirty = true;
        return statModifiers.Remove(mod);
    }

    private float CalculateFinalValue()
    {
        float finalValue = baseValue;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.type.Equals(StatModType.Flat))
            {
                finalValue += mod.value;
            }
            else if (mod.type.Equals(StatModType.Percent))
            {
                finalValue *= 1 + mod.value;
            }
            
        }

        return (float)Mathf.Round(finalValue);
    }
}
