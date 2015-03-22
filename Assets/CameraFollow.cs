using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float speed;
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = Vector3.Lerp (transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.deltaTime);
	}
}
