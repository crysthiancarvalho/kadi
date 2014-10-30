using UnityEngine;
using System.Collections;
using Facebook.MiniJSON;

public class Share : MonoBehaviour {

	private string userName;

	
	private void SetInit() {
		enabled = true; 
	}

	private void ReceiveName (FBResult result) {
		//IDictionary d = Json.Deserialize(result.Text) as IDictionary;
		//userName = d ["name"].ToString();
		string text = Application.systemLanguage == SystemLanguage.Portuguese ? " fez " : " scored ";
		string score = PlayerPrefs.GetInt("yourscore").ToString();
		string text2 = Application.systemLanguage == SystemLanguage.Portuguese ? " pontos na Fabrica de Robos" : " on Robot Factory";
		FB.Feed("", "https://play.google.com/store/apps/details?id=com.ueagames.flightcolor", "FlightColor", "", text +  score + text2, "http://computacao.uea.edu.br/ludus/face/fabricaderobos1230-630.png");
	}

	void OnMouseDown () {
		if (!FB.IsLoggedIn) {
			FB.Login("", AuthCallback);
		} else {
			AuthCallback(null);
		}
	}

	void AuthCallback(FBResult result) {
		if(FB.IsLoggedIn) {
			Debug.Log(FB.UserId);
			ReceiveName(null);
			//FB.API("me?fields=name", Facebook.HttpMethod.GET, ReceiveName);
		} else {
			Debug.Log("User cancelled login");
		}
	}

	private void OnHideUnity(bool isGameShown) {
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
	// Use this for initialization
	void Start () {	
		DontDestroyOnLoad (this.gameObject);
		enabled = false;
		FB.Init(SetInit, OnHideUnity);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
