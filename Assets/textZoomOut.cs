using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textZoomOut : MonoBehaviour {

	public int HoverOption;
	public int optionNum;
	public Text text;
	public Color hovered;
	private Color origColor;
	public Vector3 origSize;
	public Vector3 targetSize;

	// Use this for initialization
	void Start () {
		origColor = text.color;
		origSize = transform.localScale;
		targetSize = new Vector3 (transform.localScale.x - .5f, transform.localScale.y - .5f, transform.localScale.z); 
	}
	
	// Update is called once per frame
	void Update () {
		HoverOption = GameObject.Find ("Navigation").GetComponent<MenuNavigate> ().select;

		if (optionNum != HoverOption) {
			transform.localScale = Vector3.Lerp (transform.localScale,targetSize,.1f);
			text.color = Color.Lerp(text.color,origColor,.5f);
		}
		else
		{
			text.color = Color.Lerp(text.color,hovered,.5f);
			transform.localScale = origSize;
		}
	}
}
