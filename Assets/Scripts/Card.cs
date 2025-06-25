using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "ScriptableObject/Card")]
public class Card : ScriptableObject
{
    public string cardName;
    [TextArea] public string description;
    public Sprite icon;

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