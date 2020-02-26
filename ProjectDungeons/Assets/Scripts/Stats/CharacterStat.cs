using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterStat 
{
    public float baseValue;

    public virtual float Value
    {
        get
        {
            if (isDirty || baseValue != lastBaseValue)
            {
                lastBaseValue = baseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public CharacterStat()
    {
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public CharacterStat(float baseValue) : this()
    {
        this.baseValue = baseValue;
    }

    public virtual void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if(a.order < b.order)
            return -1; 
        else if (a.order > b.order)       
            return 1;       
        return 0;
    }

    public virtual bool RemoveModifier(StatModifier mod)
    {
        if (statModifiers.Remove(mod))
        {
            isDirty = true;
            return true;
        }
        return false;
    }

    public virtual bool RemoveAllModifiersFromSource(object source)
    {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0 ; i--)
        {
            if(statModifiers[i].source == source)
            {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected virtual float CalculateFinalValue()
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;

        for(int i = 0; i < statModifiers.Count; i++)
        {
            StatModifier mod = statModifiers[i];

            if (mod.type.Equals(StatModType.Flat))
            {
                finalValue += mod.value;
            }
            else if (mod.type.Equals(StatModType.PercentAdd))
            {
                sumPercentAdd += mod.value;

                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].type != StatModType.PercentAdd)
                {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            }
            else if (mod.type.Equals(StatModType.PercentMult))
            {
                finalValue *= 1 + mod.value;
            }
            
        }

        return (float)Mathf.Round(finalValue);
    }
}
