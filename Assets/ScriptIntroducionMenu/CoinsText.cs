using System;
using UnityEngine;
using UnityEngine.UI;
public class CoinsText : MonoBehaviour
{
    private static String coins;
    Text coinsText;
    // Start is called before the first frame update
    void Start()
    {
        updateCoins();

    }


    public void updateCoins() {

        coinsText = GetComponent<Text>();
        coins = PlayerPrefs.GetString("Coins");
        if (coins == "") { coins = "0"; }
        coinsText.text = "Coins: " + coins;

    }

}
