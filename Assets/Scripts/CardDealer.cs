using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardDealer : MonoBehaviour
{
    public CardBank cb;
    public List<GameObject> hand;
    public GameObject cardPrefab;
    [SerializeField] private InputActionReference cheatAction;
    public int cardOffset;

    void Start()
    {
        cb = FindFirstObjectByType<CardBank>();
    }

    void Update()
    {
        if (cheatAction.action.triggered)
        {
            DecideNumberOfCardsToGenerate();
        }
    }

    void GenerateHand(int cardNum)
    {
        int centerOffset = -cardOffset / 2 * cardNum; //starting position //This is shit but functional. Come back to this.
        //if (cardNum % 2 == 1) centerOffset -= cardOffset / 2;
        for (int i = 0; i < cardNum; i++)
        {
            //offset based on number of cards. Deal left to right
            Vector3 generationPosition = new Vector3(centerOffset, 0, 0);
            GameObject newCard = Instantiate(cardPrefab, this.gameObject.transform, true);
            newCard.transform.localPosition = generationPosition;
            newCard.GetComponent<Card>().SetCardData(PullCardSO());
            hand.Add(newCard);
            centerOffset += cardOffset;
        }
        FindAnyObjectByType<AudioManager>().Play("CardHand");
    }

    public void DecideNumberOfCardsToGenerate()
    {
        if (cb.availableCards.Count == 0)
        {
            Debug.LogWarning("Deck has run out of cards! Cannot generate hand!");
            return;
        }
        if (cb.availableCards.Count <= 3) GenerateHand(cb.availableCards.Count);
        else GenerateHand(UnityEngine.Random.Range(3, 6)); //3-5 cards per hand

    }

    private CardSO PullCardSO()
    {
        int cardID = UnityEngine.Random.Range(0, cb.availableCards.Count);
        CardSO toReturn = cb.availableCards[cardID];
        cb.PutCardInHand(toReturn); //ensure no duplicates
        return toReturn;
    }

    //Guarantees card will be in next hand
    void FreezeCard()
    {

    }

    //Removes a card from the pool, deletes card
    void BurnCard()
    {

    }

    public void DiscardHand() //making this public doesn't feel great but it shouldn't cause problems
    {
        cb.ReturnCardsToDeck();
        foreach (GameObject g in hand)
        {
            Destroy(g);
        }
    }

}
