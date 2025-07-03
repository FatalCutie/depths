using UnityEngine;
using UnityEngine.UI;

public class CardButtonUI : MonoBehaviour
{
    [SerializeField] private Button cardButton;
    [SerializeField] private CardSO cardToApply;
    [SerializeField] private CharacterBody playerBody;

    private void Awake()
    {
        // Attach the button's onClick event
        cardButton.onClick.AddListener(ApplyCard);
    }

    private void ApplyCard()
    {
        if (cardToApply != null && playerBody != null)
        {
            cardToApply.Apply(playerBody);
            Debug.Log($"Applied card: {cardToApply.cardName}");
        }
        else
        {
            Debug.LogWarning("Card or PlayerBody is not assigned.");
        }
    }
}