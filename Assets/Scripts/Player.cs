﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	private bool facingRight = true;
	private bool isInsideObject = false;

	//private bool shooting = false;
	private Vector2 directionShoot;

	public float maxSpeed = 10f;
	public float ConsSpeed = 0f;
	public float JumpForce = 1000f;

	public bool Dead = false;
	public float maxY = 1f;


	float groundRadius = 0.21f;
	public bool Grounded = false;
	public LayerMask whatIsGround;
	public Transform groundCheck;

	public bool doubleJump = false;

	bool CanDoAction
	{
		get
		{
			return !(!Dead || !isInsideObject);
		}
	}

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		Jump ();
	}

	// Update is called once per frame
	void FixedUpdate () {

		Grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		animator.SetBool ("Ground", Grounded);

		if (Grounded){
			doubleJump = false;
		}

		//if (!Died || !isInsideObject) {
		animator.SetFloat ("vSpeed", rigidbody2D.velocity.y);
		    Run ();
			if(ConsSpeed > 0 && !facingRight)
				Flip();
			else if(ConsSpeed < 0 && facingRight)
				Flip();
		//}
		Shoot ();
	}

	void Run() {
		if (Dead || isInsideObject)
			return;
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (move));
		if (move != 0) {
			this.rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		}
		//this.rigidbody2D.velocity = new Vector2 (speed, 0f);
		ConsSpeed = move;
	}

	void Jump(){

		if ((Grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space)) {
			animator.SetBool ("Ground", false);
			//animator.SetBool ("Jump", true);
			rigidbody2D.AddForce (new Vector2(0,JumpForce));

			if (!doubleJump && !Grounded){
				doubleJump = true;
			}
			//rigidbody2D.velocity = new Vector2(0f,JumpForce); // (new Vector2(0f, JumpForce));
		}
	}

	void Flip ()
	{
		if (Dead|| isInsideObject)
			return;
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.tag == "Enemy" && Grounded){
			animator.SetTrigger("Die");
			Dead = true;
		}
		/*if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "UpperGround") {
			Grounded = true;
			animator.SetBool ("Grounded", false);
		} else if (collision.gameObject.tag == "Enemy") {
			if(transform.position.y >= collision.gameObject.transform.position.y){
				//collision.gameObject.GetComponent<Kama>().Die();
			}else{
				animator.SetTrigger ("Die");
				Died = true;
			}
		} */
	}
	
	void OnCollisionExit2D(Collision2D collision){
		/*if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "UpperGround") {
			Grounded = false;
			if (collision.gameObject.tag == "UpperGround") {
				collision.gameObject.GetComponent<EdgeCollider2D> ().isTrigger = true;
			}
		}*/
	}

	void OnTriggerEnter2D(Collider2D other) {
		/*if (other.gameObject.tag == "UpperGround") {
			other.gameObject.GetComponent<EdgeCollider2D> ().isTrigger = false;
		} else if (other.gameObject.tag == "Banana") {
			other.gameObject.gameObject.GetComponent<Banana> ().Catch ();
		} */
	}

	public void OnShooted(Vector2 direction){
		/*directionShoot = direction;
		shooting = true;
		Shoot ();
*/
	}

	void Shoot(){
		/*if (transform.position.y >= maxY && shooting) {
			animator.SetBool("BarrelInside",false);
			animator.SetTrigger ("Shooted");
			rigidbody2D.velocity = new Vector2(3f * directionShoot.x,3f *directionShoot.y);
		} else if(shooting) {
			rigidbody2D.velocity = new Vector2(3f * directionShoot.x,3f *directionShoot.y);
		}*/
		//shooting = !shooting;
	}

	void OnShootFinish(){
		/*shooting = false;
		rigidbody2D.gravityScale = 8f;*/
	}

	public void MarkInsideBarrel(bool inside) {
		isInsideObject = inside;
		if (inside) {
			animator.SetBool("BarrelInside",inside);
			animator.SetFloat ("Speed", 0f);
		}
	}

}
