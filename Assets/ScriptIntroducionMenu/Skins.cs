using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.XR;
using Image = UnityEngine.UI.Image;
using Text = UnityEngine.UI.Text;

public class Skins : MonoBehaviour
{
    public int price;
    private string owned;
    private int numberSkin;
    private string aktual;
    private string aktualSkin;
    private Image [] ImageChild;
    public BuyAlert buyAlert;
    private Text[] newText;
    private string baseOwned = "10000000";

    private void Start()
    {
        aktual = PlayerPrefs.GetString("AktualSkin");

        newText = GetComponentsInChildren<Text>();
        ImageChild = GetComponentsInChildren<Image>();
        aktualSkin = Regex.Replace(gameObject.name, @"\D", "");
        numberSkin = int.Parse(aktualSkin);
        owned = PlayerPrefs.GetString("Skins");

        if (aktual == "") { 
            aktual = "0";
        }
        if (aktual != aktualSkin)
        {
            ImageChild[2].GetComponent<Image>().enabled = false;
        }else {
            ImageChild[2].GetComponent<Image>().enabled = true;
        }
        if (owned == "") {
            PlayerPrefs.SetString("Skins", baseOwned);
            owned = baseOwned;
        }
       if (owned.Length < baseOwned.Length){

            while (owned.Length < baseOwned.Length)
            {
                owned = owned + "0";
                PlayerPrefs.SetString("Skins", baseOwned);
            }

        }
        
        if (owned[numberSkin] == '1')
        {
            ImageChild[1].GetComponent<Image>().enabled = false;
            newText[0].GetComponent<Text>().text = "Owned";
        }
        else {      
            newText[0].GetComponent<Text>().text = "Price: " + price;
        }

        
    }
    private void Update()
    {
        owned = PlayerPrefs.GetString("Skins");
    }
    public void clickSkin() {

        

        if (owned[numberSkin] == '0')
        {
            string coins = PlayerPrefs.GetString("Coins");
            if (coins == "") { coins = "0"; }
                  
            if (price > int.Parse(coins))
            {

                cantBuyAlert("Not enough coins!");


            }
            else {
                openBuyAlert("Do you really want to buy?", coins);
               
            }
            
        }
        else {
            selectSkin();
        }
             
        
    }
    private void buySkin(string coins) {
        int actualCoins;
        ImageChild[1].GetComponent<Image>().enabled = false;
        StringBuilder udateOwned = new StringBuilder(owned);
        actualCoins = int.Parse(coins)-price;
        PlayerPrefs.SetString("Coins", actualCoins.ToString());
        udateOwned[numberSkin] = '1';
        owned = udateOwned.ToString();
        PlayerPrefs.SetString("Skins", owned);
        GameObject coinsTextBottom = GameObject.Find("Coins");
        coinsTextBottom.GetComponent<CoinsText>().updateCoins();
        newText[0].GetComponent<Text>().text = "Owned";

    }

    private void selectSkin  (){
        aktual = PlayerPrefs.GetString("AktualSkin");
        PlayerPrefs.SetString("AktualSkin", numberSkin.ToString());
        GameObject beforePlane = GameObject.Find("plane" + aktual);
        Image[] beforeImage = beforePlane.GetComponentsInChildren<Image>();
        beforeImage[2].GetComponent<Image>().enabled = false;        
        ImageChild[2].GetComponent<Image>().enabled = true;
    }

    private void openBuyAlert(string msg, string coins)
    {
        buyAlert.gameObject.SetActive(true);
        buyAlert.buy.gameObject.SetActive(true);
        buyAlert.buy.onClick.AddListener(() => { buyClick(coins); });
        buyAlert.back.onClick.AddListener(backClick);
        buyAlert.text.text = msg;

    }

    private void cantBuyAlert(string msg)
    {
        buyAlert.gameObject.SetActive(true);
        buyAlert.buy.gameObject.SetActive(false);
        buyAlert.back.onClick.AddListener(backClick);
        buyAlert.text.text = msg;

    }

    private void buyClick(string coins) {
        buySkin(coins);
        buyAlert.gameObject.SetActive(false);
    }

    private void backClick()
    {

        buyAlert.gameObject.SetActive(false);
    }


}


