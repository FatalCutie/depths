using UnityEngine;

public class Health : MonoBehaviour
{
    private CharacterBody body; public int CurrentHP { get; private set; }

    private void Start()
    {
        body = GetComponent<CharacterBody>();
        CurrentHP = body.GetStat(StatType.MaxHP).Value;
    }

    public void TakeDamage(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP - amount, 0, MaxHP);
    }

    public void Heal(int amount)
    {
        CurrentHP = Mathf.Clamp(CurrentHP + amount, 0, MaxHP);
    }

    public int MaxHP => body.GetStat(StatType.MaxHP).Value;
}
