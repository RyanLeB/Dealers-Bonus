using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int playerMoney = 1000;
    public int betAmount = 0;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyTextShadow;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI betTextShadow;

    
    public void Update()
    {
        moneyText.text = $"Credits: {playerMoney}";
        moneyTextShadow.text = $"Credits: {playerMoney}";
        betText.text = $"Total Bet: {betAmount}";
        betTextShadow.text = $"Total Bet: {betAmount}";
    }
    
    public void RestartBet()
    {
        betAmount = 0;
    }
    
    public void SetBetAmount(int amount)
    {
        if (amount > playerMoney)
        {
            betAmount = playerMoney;
        }
        else
        {
            betAmount = amount;
        }
    }
    
    public void Half21()
    {
        playerMoney -= betAmount / 2;
    }
    
    public void RoundWin()
    {
        playerMoney += betAmount;
    }
    
    public void RoundLose()
    {
        playerMoney -= betAmount;
    }
}
