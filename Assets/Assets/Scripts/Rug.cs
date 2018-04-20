using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour {
	public Transform player;
	//void Start() {
		//Debug.Log (rug.GetComponent<MeshFilter> ().mesh.bounds.size);
	//}
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			//Debug.Log ("enter rug");
			player.GetComponent<playerMovement> ().setDecrease (true);
		}
	}
	void OnTriggerExit(Collider col) {
		//Debug.Log ("leave rug");
		FindObjectOfType<playerMovement> ().setDecrease (false);
	}
}
