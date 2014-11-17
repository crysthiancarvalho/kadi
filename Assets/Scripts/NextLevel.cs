using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public string level_name;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			Application.LoadLevel(level_name);
		}
	}
}
