using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour {
	
	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Player") {
			Debug.Log ("player");
		}
	}
}
