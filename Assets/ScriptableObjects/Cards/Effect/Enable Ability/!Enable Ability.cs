using System;
using UnityEngine;
using Unity.VisualScripting;

//Directly enables an ability 
[CreateAssetMenu(menuName = "ScriptableObject/Card Effects/Enable Ability")]
public class EnableAbility : CardEffect
{
    public enum AbilityToEnable { CRITICAL, BLEED };
    public AbilityToEnable abe;
    public override Effect effect => Effect.ENHANCE;

    public override void Enhance()
    {
        CombatModifiers cm = FindFirstObjectByType<CombatModifiers>();
        switch (abe)
        {
            case AbilityToEnable.CRITICAL:
                cm.canPlayerCrit = true;
                return;
            case AbilityToEnable.BLEED:
                cm.isBleedEnabled = true;
                return;
        }
    }

    #region Unused Voids
    public override void Apply(CharacterBody body)
    {
        throw new NotImplementedException();
    }
    #endregion
}