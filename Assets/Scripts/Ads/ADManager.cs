using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : Singleton<ADManager>
{
    private InterstitialAd interstitial;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
    }
   
    public  void SetInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
        this.interstitial.Show();
        }
        this.RequestInterstitial();
    }



    void RequestInterstitial()
    {
        string adID = "ca-app-pub-4152565271674548/5440694988";//test reklam android
        this.interstitial = new InterstitialAd(adID);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
}
