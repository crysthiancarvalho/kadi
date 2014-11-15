using UnityEngine;
using System.Collections;

public class Andarilho_Movement : MonoBehaviour {
// This code set up a fixed looped movement, left to right, by a set pace and speed.
	
	//Setting up the pace(number of steps) and the speed of each step.
	public int pace = 100;
	public float speed = 0.07f;
	public float wait_time = 1f;
	private int trek = 0;
	private bool wait = false;
	Animator anim;
	
	// Use this for initialization
	void Start () {
		// Setting up the trek(inicial value of steps).
		trek = pace;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(wait == true)
		{
			StartCoroutine(stop());

		}
		else
		{

		move();
		}
	
	}
	
	// This code move the object a number of steps with a speed. When the number of steps equal 0 or less flip and go in the oposite direction.
	void move()
	{
		if(pace > 0)
		{
			anim.SetBool("IsMoving", true); 
			transform.position = transform.position + transform.right*speed;
			pace--;

		}
		else if(pace <= 0)
		{

			wait = true;
			transform.Rotate(0,180,0);
			pace = trek;
		}

	}

	IEnumerator stop()
	{
		anim.SetBool("IsMoving", false); 
		yield return new WaitForSeconds(wait_time);
		wait = false;
	}

}
