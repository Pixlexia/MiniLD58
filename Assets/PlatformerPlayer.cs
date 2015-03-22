using UnityEngine;
using System.Collections;

public class PlatformerPlayer : MonoBehaviour {

	// physics stuff
	public float speed;
	public float jumpAmount;
	Vector2 jumpForce;

	protected bool facingRight = true;
	protected Rigidbody2D rb;

	// jump stuff
	public Transform groundChecker;
	public LayerMask whatIsGround;
	float groundRadius = 0.2f;
	bool grounded = false;
	bool jumpAxisInUse = false;

	// Use this for initialization
	public virtual void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpForce = new Vector2 (0, jumpAmount);
	}

	// Update is called once per frame
	public virtual void FixedUpdate () {
		UpdateOnGround ();
		MovementControls ();
		JumpControls ();
	}

	public virtual void Update(){
	}

	public virtual void MovementControls(){
		// left
		if (Input.GetAxis ("Horizontal") < 0) {
			rb.velocity = new Vector2 (-speed, rb.velocity.y);
			facingRight = false;
		}
		//right 
		else if (Input.GetAxis ("Horizontal") > 0) {
			rb.velocity = new Vector2 (speed, rb.velocity.y);
			facingRight = true;
		}
		else {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}

		Debug.Log (Input.GetAxis ("Horizontal"));

	}
	
//	public virtual void MovementControls2(){
//		// movement	
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			rb.velocity = new Vector2 (speed, rb.velocity.y);
//		} else if (Input.GetKey (KeyCode.LeftArrow)) {
//			rb.velocity = new Vector2 (-speed, rb.velocity.y);
//		} else {
//			rb.velocity = new Vector2 (0, rb.velocity.y);
//		}
//	}

	public virtual void JumpControls(){
		Debug.Log (Input.GetAxis ("Jump"));
		// jump
		if (Input.GetAxisRaw("Jump") != 0 && grounded) {
			if(!jumpAxisInUse){
				Jump ();
				jumpAxisInUse = true;
			}
		}
		else if(Input.GetAxisRaw("Jump") == 0){
			jumpAxisInUse = false;
		}
	}

	public virtual void Jump(){
		rb.velocity = new Vector2 (rb.velocity.x, 0);
		rb.AddForce (new Vector2(0, jumpAmount));
		grounded = false;
	}

	public virtual void UpdateOnGround(){
		grounded = Physics2D.OverlapCircle (groundChecker.position, groundRadius, whatIsGround);
		// anim.SetBool("Grounded", grounded);
	}
}
