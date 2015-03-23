using UnityEngine;
using System.Collections;

public class BulletBounce : Bullet {
	public override void OnCollisionEnter2D(Collision2D col){
		transform.Rotate(new Vector3(0,0,180));
		vel = transform.up * speed;

		base.OnCollisionEnter2D (col);
	}
}
