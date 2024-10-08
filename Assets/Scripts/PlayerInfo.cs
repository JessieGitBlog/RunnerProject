using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Coin;
    
    [SerializeField] private CoinPanel _coinPanel;
    public void GetCoin(int value)
    {
        Coin += value;
        _coinPanel.SetCoinText(Coin);
    }
}