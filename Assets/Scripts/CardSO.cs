using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObject/Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;
    public Sprite icon;
    public List<CardSO> dependencies;
    public enum CardRarity { COMMON, RARE, LEGENDARY };
    public CardRarity cardRarity = CardRarity.COMMON;

    [SerializeReference]
    public List<CardEffect> effects = new();

    public void Apply(CharacterBody body)
    {
        foreach (var effect in effects)
        {
            effect.Apply(body);
        }
    }
}