using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    private string playstoreID = "3322562";
    private string appleID = "3322563";

    private string videoAd = "video";
    private string rewardVideoAd = "rewardedVideo";

    public bool isPlaystore;
    public bool isTestAd;

    public static AdController instance;
    // Start is called before the first frame update
    private void Awake(){
        TestSingleton();
    }

    void Start(){

        InitAds();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitAds(){
        
        if(isPlaystore){
            Monetization.Initialize(playstoreID,isTestAd);
            return;
        }
        Monetization.Initialize(appleID,isTestAd);
    }
    public void PlayVideoAds(){

        if (!Monetization.IsReady(videoAd))
        {
            return;
        }
        ShowAdPlacementContent videoAdContent = null;
        videoAdContent = Monetization.GetPlacementContent(videoAd) as ShowAdPlacementContent;
        
        if(videoAdContent == null) return;
        videoAdContent.Show();
    }
    public void PlayRewardedVideoAds(){
        if(!Monetization.IsReady(rewardVideoAd))
        {
            SSTools.ShowMessage("Check your connection!", SSTools.Position.bottom, SSTools.Time.twoSecond);
            return;
        }
        ShowAdPlacementContent rewardedVideoAdContent = null;
        rewardedVideoAdContent = Monetization.GetPlacementContent(rewardVideoAd) as ShowAdPlacementContent;

        if(rewardVideoAd == null) return;
        rewardedVideoAdContent.Show(HandleResult);
    }

    private void TestSingleton(){

        if(instance != null) {Destroy(gameObject); return;}
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void HandleResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                GameObject.FindGameObjectWithTag("Hints PopUp").GetComponent<HintsPopUp>().UnlockHint();
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}
