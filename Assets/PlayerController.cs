using UnityEngine;
using System.Collections;

public class PlayerController : PlatformerPlayer {
	GameObject shield;
	bool shielding = false;
	bool isStoppedOnShield = false;

	// hit stuff
	int hp;
	const float invulnerableTime = 3f;
	SpriteRenderer sprite;
	public bool recoveringFromHit;

	// coins
	int coins;

	// Use this for initialization
	public override void Start () {
		base.Start ();
		shield = transform.FindChild ("shield").gameObject;
		shield.SetActive (false);
		hp = 2;

		sprite = transform.FindChild("playerBody").GetComponent<SpriteRenderer> ();
		recoveringFromHit = false;
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

		LerpXSpeedToZero ();

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

	public void Hit(){
		hp--;

		if (hp <= 0){
			Die ();
		}
		else{
			InvokeRepeating("Blinking", 0, 0.05f);
			Invoke ("StopBlink", invulnerableTime);
			recoveringFromHit = true;
		}
	}

	public void Die(){
		Application.LoadLevel (Application.loadedLevelName);
	}		

	void Blinking(){
		sprite.enabled = !sprite.enabled;	
	}

	void StopBlink(){
		CancelInvoke ("Blinking");
		sprite.enabled = true;
		recoveringFromHit = false;
	}

	public void PickCoin(){
		coins++;
	}
}
