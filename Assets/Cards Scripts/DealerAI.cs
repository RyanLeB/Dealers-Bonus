using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAI : MonoBehaviour
{
    public CardDeck deck;
    public BlackJackHands dealerHand;
    public BlackJackHands playerHand;

    void Start()
    {
        Debug.Log("Starting Dealer AI");
        PlayerTurn();
    }

    public void DealerTurn()
    {
        Debug.Log("Dealer's Turn");

        while (dealerHand.GetHandValue() < 17)
        {
            Sprite card = deck.DrawCard();
            dealerHand.AddCard(card);
            Debug.Log("Dealer draws a card.");
        }

        if (dealerHand.GetHandValue() >= 17)
        {
            Debug.Log("Dealer's hand is " + dealerHand.GetHandValue() + ". Dealer stays.");
        }
    }

    public void PlayerTurn()
    {
        Debug.Log("Player's Turn");
        // Wait for player input (hit or stand)
    }

    public void PlayerHit()
    {
        Sprite card = deck.DrawCard();
        playerHand.AddCard(card);
        Debug.Log("Player draws a card.");
        // Continue player's turn
    }

    public void PlayerStand()
    {
        Debug.Log("Player stands.");
        DealerTurn();
    }
}