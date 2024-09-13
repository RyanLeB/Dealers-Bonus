using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackHands : MonoBehaviour
{
    public List<Sprite> playerCards = new List<Sprite>();
    public List<Sprite> dealerCards = new List<Sprite>();
    public int playerValue;
    public int dealerValue;
    public Transform playerCardParent;
    public Transform dealerCardParent;
    public GameObject cardPrefab;
    public TextMeshProUGUI playerValueText;
    public TextMeshProUGUI playerValueTextShadow;
    public TextMeshProUGUI dealerValueText;
    public TextMeshProUGUI dealerValueTextShadow;


    public void FixedUpdate()
    {
        GetPlayerValue();
        GetDealerValue();
    }

    public void AddCard(Sprite card, bool isPlayer)
    {
        if (isPlayer)
        {
            playerCards.Add(card);
            playerValue += GetCardValue(card);
            AdjustForAces(true);
            DisplayCard(card, true);
        }
        else
        {
            dealerCards.Add(card);
            dealerValue += GetCardValue(card);
            AdjustForAces(false);
            DisplayCard(card, false);
        }
    }

    public int GetPlayerValue()
    {
        playerValueText.text = $"Current Hand: {playerValue}";
        playerValueTextShadow.text = $"Current Hand: {playerValue}";
        return playerValue;
    }

    public int GetDealerValue()
    {
        dealerValueText.text = $"Dealer's Hand: {dealerValue}";
        dealerValueTextShadow.text = $"Dealer's Hand: {dealerValue}";
        return dealerValue;
    }

    private int GetCardValue(Sprite card)
    {
        string cardName = card.name.ToLower();
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\d+");
        System.Text.RegularExpressions.Match match = regex.Match(cardName);

        if (match.Success)
        {
            return int.Parse(match.Value); // Number cards (2-10)
        }
        else if (cardName.Contains("jack") || cardName.Contains("queen") || cardName.Contains("king"))
        {
            return 10; // Face cards
        }
        else if (cardName.Contains("ace"))
        {
            return 11; // Aces initially worth 11
        }

        return 0;
    }

    public void AdjustForAces(bool isPlayer)
    {
        int aceCount = 0;
        int value = 0;
        List<Sprite> cards = isPlayer ? playerCards : dealerCards;

        foreach (Sprite card in cards)
        {
            int cardValue = GetCardValue(card);
            if (cardValue == 11)
            {
                aceCount++;
            }
            value += cardValue;
        }

        while (value > 21 && aceCount > 0)
        {
            value -= 10; // Convert an Ace from 11 to 1
            aceCount--;
        }

        if (isPlayer)
        {
            playerValue = value;
        }
        else
        {
            dealerValue = value;
        }
    }

    private void DisplayCard(Sprite card, bool isPlayer)
    {
        Transform cardParent = isPlayer ? playerCardParent : dealerCardParent;
        GameObject cardGO = Instantiate(cardPrefab, cardParent); // Instantiates a card image
        cardGO.GetComponent<Image>().sprite = card; // Gives the Image component the card sprite
        int cardIndex = isPlayer ? playerCards.Count - 1 : dealerCards.Count - 1; // Index of the last card added
        float xOffset = cardIndex * 50f; // Offset each card by 50 pixels
        cardGO.transform.localPosition = new Vector3(xOffset, 0, 0); // Sets the cards to the same position of cardParent
    }
    
    public void ClearHands()
    {
        playerCards.Clear();
        dealerCards.Clear();
        playerValue = 0;
        dealerValue = 0;
        foreach (Transform child in playerCardParent)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in dealerCardParent)
        {
            Destroy(child.gameObject);
        }
    }
}