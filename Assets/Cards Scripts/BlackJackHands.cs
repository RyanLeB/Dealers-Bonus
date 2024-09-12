using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackHands : MonoBehaviour
{
    public List<Sprite> cards = new List<Sprite>();
    public int handValue;
    public Transform cardParent; // Parent transform to hold card images
    public GameObject cardPrefab; // Prefab for card images

    public void AddCard(Sprite card)
    {
        cards.Add(card);
        handValue += GetCardValue(card);
        AdjustForAces();
        DisplayCard(card);
    }

    public int GetHandValue()
    {
        return handValue;
    }

    private int GetCardValue(Sprite card)
    {
        string cardName = card.name; // Assuming the card name contains its rank, e.g., "2_of_hearts", "ace_of_spades"
        string[] cardParts = cardName.Split('_');
        string rank = cardParts[0];

        if (int.TryParse(rank, out int value))
        {
            return value; // Number cards (2-10)
        }
        else if (rank == "jack" || rank == "queen" || rank == "king")
        {
            return 10; // Face cards
        }
        else if (rank == "ace")
        {
            return 11; // Aces initially worth 11
        }

        return 0; // Default case, should not happen
    }

    public void AdjustForAces()
    {
        int aceCount = 0;
        handValue = 0;

        foreach (Sprite card in cards)
        {
            int cardValue = GetCardValue(card);
            if (cardValue == 11)
            {
                aceCount++;
            }
            handValue += cardValue;
        }

        while (handValue > 21 && aceCount > 0)
        {
            handValue -= 10; // Convert an Ace from 11 to 1
            aceCount--;
        }
    }

    private void DisplayCard(Sprite card)
    {
        GameObject cardGO = Instantiate(cardPrefab, cardParent);
        cardGO.GetComponent<Image>().sprite = card;
    }
}