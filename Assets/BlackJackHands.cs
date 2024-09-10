using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackJackHands : MonoBehaviour
{
    // Deck and player and dealer hands, not turns
    int [] playerHand = new int[2];
    int [] dealerHand = new int[2];
    int playerHandValue;
    int dealerHandValue;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting BlackJackHands");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
