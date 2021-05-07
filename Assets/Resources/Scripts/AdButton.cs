using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class AdButton : MonoBehaviour
{
    private InterstitialAd interstitial;
    public string adID = "ca-app-pub-3940256099942544/1033173712";

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        StartCoroutine(RequestInterstitial());
        interstitial.OnAdClosed += HandleOnAdClosed;

    }

    public IEnumerator RequestInterstitial()
    {
        interstitial = new InterstitialAd(adID);

        AdRequest adRequest = new AdRequest.Builder().Build();

        interstitial.LoadAd(adRequest);

        while (!interstitial.IsLoaded())
        {
            yield return null;
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        StartCoroutine(RequestInterstitial());

        SceneManager.LoadScene("Main");
    }

    // After watching the Ads, player can continue with its collected coins
    public void Continue()
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
    }

}
