using UnityEngine;

//Buffs abilities in CombatModifier
[CreateAssetMenu(menuName = "ScriptableObject/Card Effects/Ability Modifier")]
public class AbilityBuff : CardEffect
{
    public enum AbilityToEnhance { CRITICAL_RATE, CRITICAL_DMG, BLEED_PERCENT }
    public int enhancementPoints;
    public AbilityToEnhance abilityToEnhance;
    public override void Enhance()
    {
        CombatModifiers cm = FindFirstObjectByType<CombatModifiers>();
        switch (abilityToEnhance)
        {
            case AbilityToEnhance.CRITICAL_RATE:
                cm.criticalHitRate += enhancementPoints;
                break;
            case AbilityToEnhance.CRITICAL_DMG:
                cm.criticalHitDamageMultiplier += enhancementPoints;
                break;
            case AbilityToEnhance.BLEED_PERCENT:
                cm.bleedPercentDamage += enhancementPoints;
                break;
        }

    }

    #region Unused Voides
    public override void Apply(CharacterBody body)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}
