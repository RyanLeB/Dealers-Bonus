using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public Sprite[] cardSprites; // Array of card sprites
    private List<Sprite> deck;

    void Start()
    {
        if (cardSprites == null || cardSprites.Length == 0)
        {
            Debug.LogError("Card sprites array is not populated.");
            return;
        }
        ShuffleDeck();
    }

    public void ShuffleDeck()
    {
        deck = new List<Sprite>(cardSprites);
        for (int i = 0; i < deck.Count; i++)
        {
            Sprite temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public Sprite DrawCard()
    {
        if (deck.Count == 0)
        {
            ShuffleDeck();
        }
        Sprite drawnCard = deck[0];
        deck.RemoveAt(0);
        return drawnCard;
    }
}
