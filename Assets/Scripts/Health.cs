using UnityEngine;

public class Health : MonoBehaviour
{
    public CharacterBody body { get; private set; }
    public int currentHP { get; private set; }
    public int maxHP { get; private set; }
    public enum CharacterType { PLAYER, ENEMY }; //This will probably be relocated to characterbody 
    public CharacterType characterType = CharacterType.PLAYER;

    private void Start()
    {
        body = GetComponent<CharacterBody>();
        if (body) currentHP = body.GetStat(StatType.MaxHP).Value; //TODO: Save players health from combat to combat
        else
        {
            if (maxHP <= 0) Debug.LogWarning($"{gameObject} does not have a CharacterBody or declared MaxHP!");
            else currentHP = maxHP;
        }
    }

    public void TakeDamage(int amount)
    {
        if (body) currentHP = Mathf.Clamp(currentHP - amount, 0, MaxHP);
        else currentHP = Mathf.Clamp(currentHP - amount, 0, maxHP);
    }

    public void Heal(int amount)
    {
        if (body) currentHP = Mathf.Clamp(currentHP + amount, 0, MaxHP);
        else currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
    }

    public int MaxHP => body.GetStat(StatType.MaxHP).Value;
}
