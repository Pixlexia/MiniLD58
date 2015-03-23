using UnityEngine;
using System.Collections;

public class PlayerBody : MonoBehaviour {
	
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Bullet") {
			transform.GetComponentInParent<PlayerController>().Die();
		}
	}
}
