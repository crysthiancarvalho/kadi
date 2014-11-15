using UnityEngine;
using System.Collections;

public class Andarilho_Controller : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
		{
			DestroyObject(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		
		
		if(collider.gameObject.tag == "Player")
		{	
			Animator player = collider.gameObject.GetComponent<Animator>();
			
			if(player.GetBool("Ground") == false)
			{
				anim.SetBool("IsDead", true);
				
				
			}
		}
	}
}
