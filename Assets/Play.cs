using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	public int cameraScale;

	// Use this for initialization
	void Start () {
		float s_baseOrthographicSize = Screen.height / 16.0f / (2.0f * cameraScale);
		Camera.main.orthographicSize = s_baseOrthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
