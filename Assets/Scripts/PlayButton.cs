using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {

		anim.SetBool("IsPressed",true);
		Application.LoadLevel("Loading Screen");
	}
}
