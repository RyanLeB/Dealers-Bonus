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
    private bool playerHasStood = false;
    public AudioSource cardFlip;

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

            dealerHand.AddCard(card, false);
            Debug.Log("Dealer draws a card. Hand value: " + dealerHand.GetDealerValue());
            
            if (dealerHand.GetDealerValue() >= 17)
            {
                break;
            }
            CheckWin();
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
        if (playerHasStood)
        {
            Debug.Log("Player has already stood and cannot draw more cards.");
            return;
        }

        cardFlip.Play();
        Sprite card = deck.DrawCard();
        playerHand.AddCard(card, true);
        Debug.Log("Player draws a card.");
    }

    public void PlayerStand()
    {
        cardFlip.Play();
        Debug.Log("Player stands.");
        Debug.Log(playerHasStood);
        playerHasStood = true;
        DealerTurn();
    }

    public void CheckWin()
    {
        int playerValue = playerHand.GetPlayerValue();
        int dealerValue = dealerHand.GetDealerValue();
        
        if (playerValue > 21)
        {
            Debug.Log("Player busts. Dealer wins.");
        }
        else if (dealerValue > 21)
        {
            Debug.Log("Dealer busts. Player wins.");
        }
        else if (playerValue > dealerValue)
        {
            Debug.Log("Player wins.");
        }
        else if (dealerValue > playerValue)
        {
            Debug.Log("Dealer wins.");
        }
        else
        {
            Debug.Log("It's a tie.");
        }
    }
}