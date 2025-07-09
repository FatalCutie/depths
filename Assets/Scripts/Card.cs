using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public TextMeshProUGUI cardName;

    public CardDealer.CardMode cardMode = CardDealer.CardMode.NORMAL;
    public CharacterBody playerBody; //Cards may apply to final boss too
    public Image cardImage;
    public TextMeshProUGUI cardDescription;
    public CardSO cardData;

    void Start()
    {
        InitializeCard();
        FindPlayerBody();
    }

    //This is so silly i started laughing hysterically when I thought of it
    void FindPlayerBody()
    {
        GameObject player = FindFirstObjectByType<PlayerCombat>().gameObject;
        playerBody = player.GetComponent<CharacterBody>();
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

    public void DecideCardReactions()
    {
        switch (cardMode)
        {
            case CardDealer.CardMode.NORMAL:
                ApplyCardEffect();
                break;
            case CardDealer.CardMode.FREEZE:
                //Ensure card appears next hand
                break;
            case CardDealer.CardMode.BURN:
                //Remove card from pile
                break;
        }
    }

    public void ApplyCardEffect()
    {
        foreach (CardEffect ce in cardData.effects)
        {
            ce.Apply(playerBody);
        }
        FindFirstObjectByType<CardBank>().PickCard(cardData);
        FindFirstObjectByType<CardDealer>().DiscardHand();
        Destroy(gameObject);
    }
}
