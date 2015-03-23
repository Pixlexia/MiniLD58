using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public enum TurretDir { left, right, up, down }

	public GameObject bullet;
	public float delayBeforeFire;
	public TurretDir dir;

	// Use this for initialization
	void Start () {
		Fire ();
	}

	public virtual void Fire(){
		Invoke ("ShootBullet", delayBeforeFire);
	}

	public void ShootBullet(){
		Vector3 pos = Vector3.zero, rot = Vector3.zero;

		switch (dir) {
		case TurretDir.up:
			pos = new Vector3(0, 1, 0);
			rot = new Vector3(0,0,0);
			break;

		case TurretDir.down:
			pos = new Vector3(0, -1, 0);
			rot = new Vector3(0,0,180);
			break;

		case TurretDir.left:
			pos = new Vector3(-1, 0, 0);
			rot = new Vector3(0,0,90f);
			break;

		case TurretDir.right:
			pos = new Vector3(1, 0, 0);
			rot = new Vector3(0,0,-90f);
			break;
		}


		Instantiate (bullet, transform.position + pos, Quaternion.Euler(rot));
	}
}
