using UnityEngine;
using System.Collections;

public class Beating : MonoBehaviour {

	public int optionNum;
	public int hoverOption;
	public float lerpSpeed = 0.2f, repeatRate, scaleAmt;
	Vector3 origscale;
	bool enabled;
	
	void Awake(){
		origscale = transform.localScale;
		

		if (lerpSpeed == 0.00f)
			lerpSpeed = 0.2f;
	}

	void Start(){
			InvokeRepeating ("Beat", 1, repeatRate);
	}
	
	void Beat(){
		if (transform.parent.gameObject.name == "Buttons") {
			if (optionNum == hoverOption) {
				transform.localScale = (scaleAmt * origscale);
			}
		}
	}

	void ArrowBeat(){
		transform.localScale = (scaleAmt * origscale);
	}
	
	// Update is called once per frame
	void Update () {
		hoverOption = GameObject.Find ("Navigation").GetComponent<MenuNavigate> ().select;
		transform.localScale = Vector3.Lerp (transform.localScale, origscale, lerpSpeed);

		if ((Input.GetKeyDown (KeyCode.DownArrow)) || (Input.GetKeyDown(KeyCode.UpArrow))) {
				Invoke("ArrowBeat",0f);
		}
//		
//		if (transform.localScale.x - origscale.x <= 0.1f)
//			enabled = false;
	}
}
