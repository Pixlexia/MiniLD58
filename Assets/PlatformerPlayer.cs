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
	GameObject groundCheck;
	float groundRadius = 0.3f;
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
	}

	public virtual void Update(){
		JumpControls ();
		MovementControls ();
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
			rb.velocity = new Vector2(0, rb.velocity.y);
//			LerpXSpeedToZero();
		}
	}

	public virtual void JumpControls(){
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

	public virtual void LerpXSpeedToZero(){
		rb.velocity = Vector2.Lerp (rb.velocity, new Vector2 (0, rb.velocity.y), 12 * Time.deltaTime);
	}
}
