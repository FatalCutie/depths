using UnityEngine;

public class Health : MonoBehaviour
{
    private CharacterBody body; public int CurrentHP { get; private set; }
    public enum CharacterType { PLAYER, ENEMY }; //This will probably be relocated to characterbody 
    public CharacterType characterType = CharacterType.PLAYER;

    private void Start()
    {
        body = GetComponent<CharacterBody>();
        CurrentHP = body.GetStat(StatType.MaxHP).Value;
    }

    public void TakeDamage(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP - amount, 0, MaxHP);
        if (CurrentHP == 0 && characterType == CharacterType.ENEMY) //temp
        {
            FindFirstObjectByType<CardDealer>().DecideNumberOfCardsToGenerate();
        }
    }

    public void Heal(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + amount, 0, MaxHP);
    }

    public int MaxHP => body.GetStat(StatType.MaxHP).Value;
}
