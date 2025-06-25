using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Card Effects/Stat Modifier")]
public class StatModifierEffect : CardEffect
{
    public StatType statType;
    public float modifierValue;
    public ModifierType modifierType = ModifierType.Flat;

    public override void Apply(CharacterBody body)
    {
        var modifier = new StatModifier(modifierValue, modifierType, this);

        switch (statType)
        {
            case StatType.MaxHP:
                body.MaxHP.AddModifier(modifier);
                body.GetComponent<Health>().Heal((int)modifier.Value); // Heal HP to match new Max
                break;
            case StatType.Strength:
                body.Strength.AddModifier(modifier);
                break;
            case StatType.Agility:
                body.Agility.AddModifier(modifier);
                break;
            case StatType.Vitality:
                body.Vitality.AddModifier(modifier);
                break;
            case StatType.Luck:
                body.Luck.AddModifier(modifier);
                break;
        }
    }
}