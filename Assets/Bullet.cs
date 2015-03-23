using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	Vector3 vel;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		vel = transform.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = vel;
	}

	void OnCollisionEnter2D(Collision2D col){
		transform.Rotate(new Vector3(0,0,180));
//		transform.Rotate(new Vector3(0,0,180 + Random.Range (-5f,5f)));
		vel = transform.up * speed;
//		vel = Vector3.Reflect (rb.velocity, col.contacts [0].normal);
//		vel = new Vector3(-vel.x + Random.Range(-2f, 2f), -vel.y, vel.z);
//		Debug.Log (vel.x + " " + vel.y);

		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Main Camera").GetComponent<CameraShake>().Shake();
		}
	}
}