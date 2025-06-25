using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public int BaseValue { get; private set; }
    private List<StatModifier> modifiers = new();

    public Stat(int baseValue)
    {
        BaseValue = baseValue;
    }

    public int Value
    {
        get
        {
            float finalValue = BaseValue;
            float percent = 0f;

            foreach (var mod in modifiers)
            {
                if (mod.Type == ModifierType.Flat)
                    finalValue += mod.Value;
                else if (mod.Type == ModifierType.Percent)
                    percent += mod.Value;
            }

            finalValue += finalValue * percent;
            return Mathf.FloorToInt(finalValue);
        }
    }

    public void AddModifier(StatModifier mod) => modifiers.Add(mod);
    public void RemoveModifier(StatModifier mod) => modifiers.Remove(mod);
    public void ClearModifiersFromSource(object source) =>
        modifiers.RemoveAll(m => m.Source == source);
}