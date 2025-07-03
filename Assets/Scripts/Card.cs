using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI cardName;
    public CharacterBody playerBody; //Try and clean this up later
    public Image cardImage;
    public TextMeshProUGUI cardDescription;
    public CardSO cardData;

    void Start()
    {
        InitializeCard();
    }

    void InitializeCard()
    {
        if (!cardData)
        {
            Debug.LogWarning("Warning: Card is being Initialized without Data!");
            return;
        }

        cardName.text = cardData.cardName;
        cardImage.sprite = cardData.icon;
        cardDescription.text = cardData.description;
    }

    public void SetCardData(CardSO cd)
    {
        cardData = cd;
        InitializeCard();
    }

    public void ApplyCardEffect()
    {
        foreach (CardEffect ce in cardData.effects)
        {
            ce.Apply(playerBody);
        }
        Destroy(gameObject);
    }
}
