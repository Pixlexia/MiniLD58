using UnityEngine;
using System.Collections;

public class textZoomOut : MonoBehaviour {

	public int HoverOption;
	public int optionNum;

	public Vector3 origSize;
	public Vector3 targetSize;

	// Use this for initialization
	void Start () {
		origSize = transform.localScale;
		targetSize = new Vector3 (transform.localScale.x - .5f, transform.localScale.y - .5f, transform.localScale.z); 
	}
	
	// Update is called once per frame
	void Update () {
		HoverOption = GameObject.Find ("Navigation").GetComponent<MenuNavigate> ().select;

		if (optionNum != HoverOption) {
			transform.localScale = Vector3.Lerp (transform.localScale,targetSize,.5f);

		}
		else
		{
			transform.localScale = origSize;
		}
	}
}
