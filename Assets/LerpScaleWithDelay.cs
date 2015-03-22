using UnityEngine;
using System.Collections;

public class LerpScaleWithDelay : MonoBehaviour {
	public bool randomDelay;
	public float delay, lerpamt;
	public float scaleAmt;
	Vector3 targetBig, targetSmall, target;
	
	// Use this for initialization
	void Start () {
		
		if (randomDelay)
			delay = Random.Range (0f, 0.8f);
		
		targetBig = transform.localScale * scaleAmt;
		targetSmall = transform.localScale;
		
		target = targetBig;
		
		//		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
		
		if (delay <= 0) {
			transform.localScale = Vector3.Lerp(transform.localScale, target, lerpamt);		
			
			if(transform.localScale.x >= (targetBig.x * 0.8f)){
				target = targetSmall;	
			}
		}
	}
}