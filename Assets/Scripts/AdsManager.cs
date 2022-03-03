using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{


    public bool disableBanner;
    // Start is called before the first frame update

    void Awake() {

        Advertisement.Initialize("4639885");
        if (!disableBanner)
        {
            ShowBanner();
        }
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayAd() {

        if (Advertisement.IsReady("interstetial")) {
            Advertisement.Show("interstetial");

        }

    }

    public void ShowBanner() {


        if (Advertisement.IsReady("Banner"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner");

        }
        else {
            StartCoroutine(RepeatShowBanner());
        }

    }

    public void HideBanner() {
        Advertisement.Banner.Hide();
    }

    IEnumerator RepeatShowBanner() {

        yield return new WaitForSeconds(1);
        ShowBanner();

    }

}
