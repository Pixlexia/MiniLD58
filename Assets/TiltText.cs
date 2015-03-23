using UnityEngine;
using System.Collections;

public class TiltText : MonoBehaviour {

	public int OptionNum;
	public float tiltAngle;

	private int HoverOption;
	private Quaternion targetTilt;
	private Quaternion originalTilt;

	// Use this for initialization
	void Start () {
		targetTilt = Quaternion.Euler (transform.localRotation.x, transform.localRotation.y, tiltAngle);
		originalTilt = Quaternion.Euler (transform.localRotation.x, transform.localRotation.y, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		HoverOption = GameObject.Find ("Navigation").GetComponent<MenuNavigate> ().select;

		if (OptionNum == HoverOption) {
			Tilt (targetTilt);
		} else if (OptionNum != HoverOption){
			TiltBack(originalTilt);
		}
	}

	void Tilt(Quaternion target){
		transform.localRotation = Quaternion.Lerp (transform.localRotation, target, .5f);
	}
	void TiltBack(Quaternion target){
		transform.localRotation = Quaternion.Lerp (transform.localRotation, originalTilt, .5f);
	}
}
