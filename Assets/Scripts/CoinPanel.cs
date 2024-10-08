using TMPro;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    public void SetCoinText(int value)
    {
        coinText.text = value.ToString();
    }
}