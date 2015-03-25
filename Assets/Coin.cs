using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	bool isPicked;
	Vector3 origPos, targetPos;

	void Update(){
		if (isPicked) {
			transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
//		Debug.Log (col.gameObject.name);
		if (col.gameObject.tag == "Player") {
			Picked(col.gameObject);
		}
	}

	void Picked(GameObject go){
		go.GetComponentInParent<PlayerController> ().PickCoin ();
		isPicked = true;
		targetPos = transform.position + new Vector3 (0, 2, 0);
		Invoke ("Die", 1);
	}

	void Die(){
		Destroy (transform.parent.gameObject);
	}
}
