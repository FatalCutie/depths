using UnityEngine;

public abstract class CardEffect : ScriptableObject
{
    public enum Effect { APPLY, ENHANCE }
    public virtual Effect effect => Effect.ENHANCE;
    //This is a sloppy way to do things but if I have a better idea I encourage future me to fix it
    //(he wont)
    public abstract void Apply(CharacterBody body);
    public abstract void Enhance();
    //public abstract void DecideUniqueAbility();
}