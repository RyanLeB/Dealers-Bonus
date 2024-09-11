using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackHands : MonoBehaviour
{
    // Deck and player and dealer hands, not turns
    public List<Sprite> cards = new List<Sprite>();
    public int handValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting BlackJackHands");
    }

    public void AddCard(Sprite card)
    {
        cards.Add(card);
        handValue += GetCardValue(card);
    }
    
    public int GetHandValue()
    {
        return handValue;
    }
    
    private int GetCardValue(Sprite card)
    {
        string cardName = card.name; // Get the name of the card
        string[] cardNameParts = cardName.Split('_'); // Split the card name by the underscore character
        string rank = cardNameParts[0]; // The rank of the card is the first part of the card name
        
        // If the rank is a number, return the integer value of the rank
        if (int.TryParse(rank, out int rankValue))
        {
            return rankValue;
        }
        else if (rank == "jack" || rank == "queen" || rank == "king")
        {
            return 10;
        }
        else if (rank == "ace")
        {
            return 11;
        }
        else
        {
            return 0;
        }
    }
    
    public void AdjustAceValue()
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
            handValue -= 10;
            aceCount--;
        }
    }

    public void ShuffleCards()
    {
        // Shuffles the cards with an loop
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1); // Random
            Sprite face = cards[i];
            cards[i] = cards[j];
            cards[j] = face;
            
            int value = GetCardValue(cards[i]);
            GetCardValue(i) = GetCardValue(j);
            GetCardValue(j) = value;
        }
    }
}
