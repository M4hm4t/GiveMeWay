using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{
    private InterstitialAd interstitial;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestInterstitial();
    }
    private void Update()
    {
       // SetInterstitialAd();
    }
    public  void SetInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
        this.interstitial.Show();
        }
    }



    void RequestInterstitial()
    {
        string adID = "ca-app-pub-3940256099942544/1033173712";//test reklam android
        this.interstitial = new InterstitialAd(adID);
        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }
}
