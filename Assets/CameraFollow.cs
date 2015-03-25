using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3(target.position.x, target.position.y + 1, transform.position.z), speed * Time.deltaTime);

	}
}
