using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int minutes = 2;
	public float seconds = 0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!(minutes <= 0 && seconds <= 0))
		{
		if(seconds <= 0)
		{
			minutes--;
			seconds = 59;
		}
		else
		{
			seconds = seconds - Time.deltaTime;
		}
		}
	}

	void OnGUI ()
	{
		GUI.Box(new Rect(10,10,50,20), "" + minutes.ToString("0") + ":" + seconds.ToString("00"));
	}
}
