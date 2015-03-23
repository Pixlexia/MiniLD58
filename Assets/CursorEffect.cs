using UnityEngine;
using System.Collections;

public class CursorEffect : MonoBehaviour {

	public float maxAngle, minAngle, dur;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Swing ();
	}

	void Swing(){
		transform.rotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y,
		                                             Mathf.PingPong(Time.time * dur, maxAngle-minAngle)+minAngle);
	}
}
