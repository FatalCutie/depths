using System.Collections.Generic;
using UnityEngine;

public class CharacterBody : MonoBehaviour
{
    [SerializeField] private CharacterStatsSO baseStats;

    // Dictionary to store all runtime stats
    private Dictionary<StatType, Stat> stats = new();

    // Expose key stats if needed
    public Stat MaxHP => stats[StatType.MaxHP];
    public Stat Strength => stats[StatType.Strength];
    public Stat Agility => stats[StatType.Agility];
    public Stat Vitality => stats[StatType.Vitality];
    public Stat Luck => stats[StatType.Luck];

    private void Awake()
    {
        // Initialize all stats based on the baseStats ScriptableObject
        stats[StatType.MaxHP] = new Stat(baseStats.maxHealth);
        stats[StatType.Strength] = new Stat(baseStats.baseStrength);
        stats[StatType.Agility] = new Stat(baseStats.baseAgility);
        stats[StatType.Vitality] = new Stat(baseStats.baseVitality);
        stats[StatType.Luck] = new Stat(baseStats.baseLuck);
        PrintStats();
    }

    // Get a runtime Stat instance by StatType
    public Stat GetStat(StatType type)
    {
        return stats.TryGetValue(type, out var stat) ? stat : null;
    }

    // Add a modifier to a specific stat
    public void AddModifier(StatType type, StatModifier modifier)
    {
        if (stats.TryGetValue(type, out var stat))
            stat.AddModifier(modifier);
    }

    // Remove all modifiers from a specific source
    public void RemoveModifiersFromSource(object source)
    {
        foreach (var stat in stats.Values)
        {
            stat.ClearModifiersFromSource(source);
        }
    }

    // Print all current stat values for debugging
    public void PrintStats()
    {
        foreach (var pair in stats)
        {
            Debug.Log($"{pair.Key}: {pair.Value.Value}");
        }
    }
}