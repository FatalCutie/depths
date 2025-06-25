using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Character Stats")]
public class CharacterStatsSO : ScriptableObject
{
    public int maxHealth;
    public int baseStrength;
    public int baseVitality;
    public int baseAgility;
    public int baseLuck;
}