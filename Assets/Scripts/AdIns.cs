
using UnityEngine;
using GoogleMobileAds.Api;

public class AdIns : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-2771443006207374/3192777923";
#elif UNITY_IPHONE
          private string _adUnitId = "ca-app-pub-2771443006207374/4867033500";
#else
          private string _adUnitId = "unused";
#endif
    private void Awake()
    {


        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            
        });
    }

    void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            RequestInterstitial();
        });


    }

    private void RequestInterstitial()
    {

        // Clean up interstitial before using it
        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        AdRequest request = new AdRequest();
        InterstitialAd.Load(_adUnitId, request, (InterstitialAd ads, LoadAdError loadAdError) =>
        {
            if (loadAdError != null)
            {
                return;
            }
            else
            if (ads == null)
            {
                return;
            }
          //  Debug.Log("Interstitial ad loaded");
            interstitial = ads;

        });
    }

    public bool canAdShow()
    {

        return (interstitial != null && interstitial.CanShowAd());

    }

    public void ShowInterstitialAd()  // Show
    {
        if (interstitial != null && interstitial.CanShowAd())
        {
            interstitial.Show();
        }
    }


}

