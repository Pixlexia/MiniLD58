using UnityEngine;
using System.Collections;

public class Beating : MonoBehaviour {
	
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
		transform.localScale = (scaleAmt * origscale);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.Lerp (transform.localScale, origscale, lerpSpeed);
//		
//		if (transform.localScale.x - origscale.x <= 0.1f)
//			enabled = false;
	}
}
