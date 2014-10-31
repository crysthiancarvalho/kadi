using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	private bool facingRight = true;
	private bool isInsideObject = false;

	private bool shooting = false;
	private Vector2 directionShoot;

	public float Speed = 3f;
	public float ConsSpeed = 0f;
	public float JumpForce = 1000f;
	public bool Grounded = true;
	public bool Died = false;
	public float maxY = 1f;

	bool CanDoAction
	{
		get
		{
			return !(!Died || !isInsideObject);
		}
	}

	// Use this for initialization
	void Awake () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		movement ();
	}

	void movement(){
		/*if (Input.GetAxis("Horizontal") > 0 ){

		}*/
		Run ();
		Jump ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//if (!Died || !isInsideObject) {
			
			if(ConsSpeed > 0 && !facingRight)
				Flip();
			else if(ConsSpeed < 0 && facingRight)
				Flip();
		//}
		Shoot ();
	}

	void Run() {
		if (Died || isInsideObject)
			return;
		float speed = Input.GetAxis ("Horizontal");
		animator.SetFloat ("Speed", Mathf.Abs (speed));
		if (speed != 0) {
			speed *= Speed;
			this.rigidbody2D.velocity = new Vector2 (speed, 0f);
		}
		//this.rigidbody2D.velocity = new Vector2 (speed, 0f);
		ConsSpeed = speed;
	}

	void Jump(){
		if (Died || isInsideObject)
			return;
		if (Grounded && Input.GetKeyDown(KeyCode.Space)) {
			animator.SetTrigger("Pulo");
			//animator.SetBool ("Jump", true);
			rigidbody2D.velocity = new Vector2(0f,JumpForce); // (new Vector2(0f, JumpForce));
		}
	}

	void Flip ()
	{
		if (Died || isInsideObject)
			return;
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "UpperGround") {
			Grounded = true;
			//animator.SetBool ("Jump", false);
		} else if (collision.gameObject.tag == "Enemy") {
			if(transform.position.y >= collision.gameObject.transform.position.y){
				//collision.gameObject.GetComponent<Kama>().Die();
			}else{
				animator.SetTrigger ("Die");
				Died = true;
			}
		} 
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
		directionShoot = direction;
		shooting = true;
		Shoot ();
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
		shooting = false;
		rigidbody2D.gravityScale = 8f;
	}

	public void MarkInsideBarrel(bool inside) {
		isInsideObject = inside;
		if (inside) {
			animator.SetBool("BarrelInside",inside);
			animator.SetFloat ("Speed", 0f);
		}
	}

}
