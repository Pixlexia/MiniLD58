using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 10;
	public int hp = -1; // -1 means infinite

	protected Vector3 vel;
	protected Rigidbody2D rb;

	// Use this for initialization
	public virtual void Start () {
		rb = GetComponent<Rigidbody2D> ();
		vel = transform.up * speed;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		rb.velocity = vel;
	}

	public virtual void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Play.CamShake();
//			GameObject.Find ("Main Camera").GetComponent<CameraShake>().Shake();
		}

		if (hp != -1) {
			hp--;
			if(hp <= 0){
				Die();
			}
		}
	}

	public virtual void Die(){
		Destroy (this.gameObject);
	}
}