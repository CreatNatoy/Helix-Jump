using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADSManager : MonoBehaviour
{
    private BannerView _banner;
    private const string _adUnitID = "ca-app-pub-2872685892021717/5168456881";

    void Start()
    {
        MobileAds.Initialize(initStatu => { });

        ShowBanner();
    }

    private void ShowBanner()  //показать баннер
    {
        _banner = new BannerView(_adUnitID, AdSize.Banner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        _banner.LoadAd(request);

    }
}
