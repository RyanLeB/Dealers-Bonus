using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAI : MonoBehaviour
{
    public BlackJackHands playerHand;
    public BlackJackHands dealerHand;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Dealer AI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void DealerTurn()
    //{
    //    Debug.Log("Dealer's Turn");

    //    // Get the Dealer's current hand value
    //    int dealerHandValue = GetComponent<BlackJackHands>().GetHandValue();

    //    // If the Dealer's hand is less than 17, draw a card
    //    while (dealerHandValue < 17)
    //    {
    //        // Draw a card
    //        GetComponent<CardDeck>().DrawCard(GetComponent<BlackJackHands>());
    //        dealerHandValue = GetComponent<BlackJackHands>().GetHandValue();
    //    }

    //    // If the Dealer's hand is 17 or more, stay
    //    if (dealerHandValue >= 17)
    //    {
    //        Debug.Log("Dealer's hand is " + dealerHandValue + ". Dealer stays.");
    //    }
        
    //    // After the dealer's turn, it is the player's turn
    //    PlayerTurn();
    //}
    
    public void PlayerTurn()
    {
        Debug.Log("Player's Turn");
        
        // Get the Player's current hand value
        int playerHandValue = GetComponent<BlackJackHands>().GetHandValue();
    }
}
