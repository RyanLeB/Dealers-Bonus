using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAI : MonoBehaviour
{
    public CardDeck deck;
    public BlackJackHands dealerHand;
    public BlackJackHands playerHand;
    public Transform cardOffsetDealer;
    public Transform cardOffsetPlayer;

    void Start()
    {
        Debug.Log("Starting Dealer AI");
        PlayerTurn();
    }

    public void DealerTurn()
    {
        Debug.Log("Dealer's Turn");

        if (deck == null)
        {
            Debug.LogError("Deck is not initialized.");
            return;
        }

        if (dealerHand == null)
        {
            Debug.LogError("Dealer hand is not initialized.");
            return;
        }

        while (dealerHand.GetDealerValue() < 17)
        {
            Sprite card = deck.DrawCard();
            if (card == null)
            {
                Debug.LogError("No more cards in the deck.");
                break;
            }

            dealerHand.AddCard(card, false); // false indicates it's the dealer's card
            Debug.Log("Dealer draws a card. Hand value: " + dealerHand.GetDealerValue());

            // Safety check to prevent infinite loop
            if (dealerHand.GetDealerValue() >= 17)
            {
                break;
            }
        }

        Debug.Log("Dealer's hand is " + dealerHand.GetDealerValue() + ". Dealer stays.");
    }

    public void PlayerTurn()
    {
        Debug.Log("Player's Turn");
        // Wait for player input (hit or stand)
    }

    public void PlayerHit()
    {
        Sprite card = deck.DrawCard();
        playerHand.AddCard(card, true); // true indicates it's the player's card
        Debug.Log("Player draws a card.");
        // Continue player's turn
    }

    public void PlayerStand()
    {
        Debug.Log("Player stands.");
        DealerTurn();
    }
}