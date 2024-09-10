using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAI : MonoBehaviour
{
    // Want the dealer to draw cards until they have 17 or more, and after each turn the Player will have the option to draw a card or stay
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Dealer AI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealerTurn()
    {
        Debug.Log("Dealer's Turn");

        // Get the Dealer's current hand value
        int dealerHandValue = GetComponent<Hand>().getHandValue();

        // If the Dealer's hand is less than 17, draw a card
        while (dealerHandValue < 17)
        {
            // Draw a card
            GetComponent<Deck>().DrawCard(GetComponent<Hand>());
            dealerHandValue = GetComponent<Hand>().getHandValue();
        }

        // If the Dealer's hand is 17 or more, stay
        if (dealerHandValue >= 17)
        {
            Debug.Log("Dealer's hand is " + dealerHandValue + ". Dealer stays.");
        }
    }
}
