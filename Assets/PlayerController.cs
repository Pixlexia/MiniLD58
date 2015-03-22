using UnityEngine;
using System.Collections;

public class PlayerController : PlatformerPlayer {

	public GameObject shield;

	bool shielding = false;
	bool isStoppedOnShield = false;

	// Use this for initialization
	public override void Start () {
		base.Start ();
		shield = transform.FindChild ("shield").gameObject;
		shield.SetActive (false);
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
		ShieldControls ();
	}

	public override void MovementControls(){
		if (!shielding) {
			base.MovementControls();
		}
	}

	void ShieldControls(){
		// pressing shied button
		if (Input.GetAxisRaw ("Shield") != 0) {
			Shielding();

			if(!isStoppedOnShield){
				rb.velocity = new Vector2(0, rb.velocity.y);
				isStoppedOnShield = true;
			}
		}
		// released
		else {
			if(isStoppedOnShield){
				isStoppedOnShield = false;
				shield.SetActive(false);
			}
			shielding = false;
		}
	}

	void Shielding(){
		shielding = true;

		float xaxis = Input.GetAxis ("Horizontal");
		float yaxis = Input.GetAxis ("Vertical");

		float ypos;
		float rotation = 0;

		if (xaxis != 0 || yaxis != 0) {
			shield.SetActive(true);
			shield.transform.localPosition = new Vector2 ((yaxis != 0) ? xaxis * 0.75f : xaxis, (xaxis != 0) ? yaxis * 0.75f : yaxis);
		}
		else if(shield.activeSelf) {
			shield.SetActive(false);
		}

		if (xaxis > 0) {
			if(yaxis > 0) rotation = 45f;
			else if(yaxis < 0) rotation = -45f;
			else rotation = 0;
		}
		else if(xaxis < 0){
			if(yaxis > 0) rotation = -45f;
			else if(yaxis < 0) rotation = 45f;
			else rotation = 0;
		}
		else{
			rotation = 90f;
		}

		shield.transform.rotation = Quaternion.Euler(new Vector3(0,0,rotation));

	}
}
