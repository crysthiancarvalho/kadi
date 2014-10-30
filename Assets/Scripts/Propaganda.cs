using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;

public class Propaganda : MonoBehaviour {
	InterstitialAd interstitial = new InterstitialAd("ca-app-pub-9658986592227401/3469635577");
	// Use this for initialization
	void Start () {

		AdRequest request = new AdRequest.Builder().Build();
		interstitial.LoadAd(request);
		interstitial.AdLoaded += Show;
	
	}

	void Show(object sender, System.EventArgs args)
	{
		if (interstitial.IsLoaded ()) 
		{
				interstitial.Show ();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
