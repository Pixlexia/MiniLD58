using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public enum TurretDir { left, right, up, down }
	public enum TurretType { repeating, detect }

	public GameObject bullet;
	public float bulletSpeed;
	public float delayBeforeFire;
	public TurretType type;
	public float range = 6;

	LayerMask raycastLayers;

	// Use this for initialization
	void Start () {
		// change this if add more layers
		raycastLayers.value = -513;

		if (type == TurretType.repeating) {
			InvokeRepeating ("Fire", 0, delayBeforeFire);
		}
	}

	public virtual void Update(){
		if (type == TurretType.detect) {
			RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up, transform.up, range, raycastLayers);
			if(hit.collider != null){
				Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.gameObject.tag == "Player")
					ShootBullet();
			}
		}
	}

	public virtual void Fire(){
		Invoke ("ShootBullet", delayBeforeFire);
	}

	public void ShootBullet(){
		GameObject go = Instantiate (bullet, transform.position + transform.up, transform.localRotation) as GameObject;
		go.GetComponent<Bullet> ().hp = 1;

		if(bulletSpeed != 0)
			go.GetComponent<Bullet> ().speed = bulletSpeed;
	}
}
