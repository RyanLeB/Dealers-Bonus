using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DealerAI : MonoBehaviour
{
    public CardDeck deck;
    public BlackJackHands dealerHand;
    public BlackJackHands playerHand;
    public Transform cardOffsetDealer;
    public Transform cardOffsetPlayer;
    private bool playerHasStood = false;
    public MoneyManager moneyManager;
    public AudioSource cardFlip;
    
    public GameObject winScreen;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI winTextShadow;
    public GameObject loseScreen;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI loseTextShadow;
    public GameObject tieScreen;
    public TextMeshProUGUI tieText;
    public TextMeshProUGUI tieTextShadow;

    void Start()
    {
        Debug.Log("Starting Dealer AI");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        tieScreen.SetActive(false);
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
            
            Invoke("CheckWin", 1.5f);
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
        if (playerHand.GetPlayerValue() >= 21)
        {
            Debug.Log("Player has reached 21 or higher and cannot draw more cards.");
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
            moneyManager.RoundLose();
            loseScreen.SetActive(true);
            loseText.text = "Lost:" + moneyManager.betAmount + "$";
            loseTextShadow.text = "Lost:" + moneyManager.betAmount + "$";
            Debug.Log("Player busts. Dealer wins.");
        }
        else if (dealerValue > 21)
        {
            moneyManager.RoundWin();
            winScreen.SetActive(true);
            winText.text = "Winnings:" + moneyManager.betAmount + "$";
            winTextShadow.text = "Winnings:" + moneyManager.betAmount + "$";
            Debug.Log("Dealer busts. Player wins.");
        }
        else if (dealerValue == 21)
        {
            moneyManager.Half21();
            loseScreen.SetActive(true);
            loseText.text = "Lost:" + moneyManager.betAmount + "$";
            loseTextShadow.text = "Lost:" + moneyManager.betAmount + "$";
            Debug.Log("Dealer has 21. Player loses half of their bet.");
        }
        else if (playerValue > dealerValue)
        {
            moneyManager.RoundWin();
            winScreen.SetActive(true);
            winText.text = "Winnings:" + moneyManager.betAmount + "$";
            winTextShadow.text = "Winnings:" + moneyManager.betAmount + "$";
            Debug.Log("Player wins.");
        }
        else if (dealerValue > playerValue)
        {
            moneyManager.RoundLose();
            loseScreen.SetActive(true);
            loseText.text = "Lost:" + moneyManager.betAmount + "$";
            loseTextShadow.text = "Lost:" + moneyManager.betAmount + "$";
            Debug.Log("Dealer wins.");
        }
        else
        {
            tieScreen.SetActive(true);
            tieText.text =  "Credits Returned:" + moneyManager.playerMoney + "$";
            tieTextShadow.text =  "Credits Returned:" + moneyManager.playerMoney + "$";
            Debug.Log("It's a tie.");
        }
    }
    
    public void RestartGame()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        tieScreen.SetActive(false);
        playerHand.playerCards.Clear();
        playerHand.playerValue = 0;
        dealerHand.dealerCards.Clear();
        dealerHand.dealerValue = 0;
        playerHasStood = false;
        deck.ShuffleDeck();
        playerHand.GetPlayerValue();
        dealerHand.GetDealerValue();
        playerHand.ClearHands();
        Start();
    }
}