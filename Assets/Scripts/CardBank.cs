using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardBank : MonoBehaviour
{
    public List<CardSO> availableCards;
    [SerializeField] private List<CardSO> unavailableCards;
    [SerializeField] private List<CardSO> pickableCardHand;
    [SerializeField] private List<CardSO> pickedCards;
    [SerializeField] private List<CardSO> unlockCardsBuffer;

    //Move card from availableCards to picked
    public void PickCard(CardSO card)
    {
        pickedCards.Add(card);
        pickableCardHand.Remove(card);
        ReturnCardsToDeck();
        CheckCardDependencies(card);
    }

    public void MakeCardAvailable(CardSO card)
    {
        //Debug.Log($"Making {card.cardName} available!");
        availableCards.Add(card);
        unavailableCards.Remove(card);
    }

    public void PutCardInHand(CardSO card)
    {
        pickableCardHand.Add(card);
        availableCards.Remove(card);
    }

    public void ReturnCardsToDeck()
    {
        foreach (CardSO c in pickableCardHand.ToList())
        {
            availableCards.Add(c);
            pickableCardHand.Remove(c);
        }
    }

    //Add card to buffer to prevent chain unlocking cards while checking for dependencies
    public void AddCardToBuffer(CardSO c)
    {
        unlockCardsBuffer.Add(c);
        unavailableCards.Remove(c);
    }

    public void UnlockCardsFromBuffer()
    {
        foreach (CardSO c in unlockCardsBuffer.ToList())
        {
            //Debug.Log($"Unlocking card {c.cardName}");
            availableCards.Add(c);
            unlockCardsBuffer.Remove(c);
        }
    }

    private void CheckCardDependencies(CardSO card)
    {
        List<CardSO> dependentCards = unavailableCards.FindAll(x => x.dependencies.Contains(card));
        //Debug.Log($"Card dependencies: {dependentCards.Count}");
        //Checks to see if all dependencies are in pickedCards
        foreach (CardSO c in dependentCards)
        {
            //Skip hard work if only dependency
            if (c.dependencies.Count == 1)
            {
                //Debug.Log($"Only one dependency for {c.cardName}, unlocking!");
                AddCardToBuffer(c);
                continue;
            }

            int i = 0; //This is probably unoptimal but I'm blanking on a slicker way to do it
            foreach (CardSO dependency in c.dependencies.ToList())
            {
                if (!pickedCards.Contains(dependency)) break;
                else i++;
            }
            if (i == c.dependencies.Count)
            {
                AddCardToBuffer(c);
            }
        }
        UnlockCardsFromBuffer();
    }
}
