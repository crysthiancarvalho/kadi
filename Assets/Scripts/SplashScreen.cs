using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float splash_loadtime = 2f;
	public string level_name="Tela Menu";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine(waitSplashScreen());
	}

	IEnumerator waitSplashScreen()
	{
		yield return new WaitForSeconds(splash_loadtime);
		Application.LoadLevel(level_name);
	}
}
