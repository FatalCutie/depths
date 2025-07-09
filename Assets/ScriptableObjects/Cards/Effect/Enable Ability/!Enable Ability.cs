using UnityEngine;

public class EnableAbility : CardEffect
{
    public override void Apply(CharacterBody body)
    {
        //Should be able to flip a boolean from combat modifiers
        FindFirstObjectByType<CombatModifiers>();
        //TODO: Will allow me to select a boolean from CombatModifiers and enable it
    }
}
