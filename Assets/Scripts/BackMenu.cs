using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMenu : MonoBehaviour
{


    public Button yourButton;
    public Button restart;
    public Button continueGame;
    private GameObject adIns;
 //   public GameObject ad;

    void Start()
    {
       
        Button btn = yourButton.GetComponent<Button>();
        Button btn2 = restart.GetComponent<Button>();
        Button btn3 = continueGame.GetComponent<Button>();
        adIns = GameObject.Find("AdIns");

        //  GameObject adIns = Instantiate(ad);
        //  adIns.GetComponent<AdIns>().Show_InterstitialAd();



        // a.GetComponent<AdIns>().Show_InterstitialAd();
        try { var ad = adIns.GetComponent<Rewarded>();

            btn3.gameObject.SetActive(ad.readyAdd());
        }
        catch { btn3.gameObject.SetActive(false); }
 
        btn.onClick.AddListener(TaskOnClick);   
        btn2.onClick.AddListener(RestartOnClick);
        btn3.onClick.AddListener(ContinueOnClick);


    }

    void TaskOnClick()
    {
        FindAnyObjectByType<AudioManager>().Stop("BosSound");
        FindAnyObjectByType<AudioManager>().Play("BackGround");
        FindAnyObjectByType<InGameManager>().EndGame();
       
    }
    void RestartOnClick()
    {
        FindAnyObjectByType<AudioManager>().Stop("BosSound");
        FindAnyObjectByType<AudioManager>().Play("BackGround");
        SceneManager.LoadScene("Game");
    }

    void ContinueOnClick()
    {
        adIns = GameObject.Find("AdIns");
        adIns.GetComponent<Rewarded>().ShowRewardedAd(gameObject);
    }



}



