using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    private TextMeshProUGUI coinText;

    private void Awake()
    {
        coinText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin").ToString();        
    }
}