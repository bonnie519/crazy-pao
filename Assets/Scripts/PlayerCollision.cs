using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	Color[] colors = {Color.black,Color.blue,Color.red};
 	int index = 0;
	public playerMovement movement;
	public float restartDelay = 1f;
	private bool startRug = false;
	private void Restart() {
		movement.enabled = true;
		//movement.setForce (200f,0);
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log (collision.collider.tag);
		if (collision.collider.tag == "Obstacle") {
			//movement.enabled = false;
			// if has 0 life left, end game 
			if (collision.collider.gameObject.GetComponent<Renderer> ().material.color == this.GetComponent<Renderer> ().material.color) {
				Debug.Log ("same color");
				collision.collider.transform.GetComponent<BoxCollider> ().isTrigger = true;				
				index = (index++) % colors.Length;
				this.GetComponent<Renderer> ().material.color = colors [index];
			} else {
				Debug.Log ("diff color");

				//this.GetComponent<Renderer> ().material.color = blend(this.GetComponent<Renderer> ().material.color,
					//collision.collider.gameObject.GetComponent<Renderer> ().material.color);
				FindObjectOfType<GameManager> ().EndGame ();
			}
			// else
			//restart game
		} else if (collision.collider.tag == "Rug") {

			if (!startRug) {
				startRug = true;
				Debug.Log ("enter rug zone");
				//movement.enabled = false;
				//Invoke("Decrease", Time.deltaTime);
				movement.setDecrease (true);
			}
		} else if (collision.collider.tag == "Ground") {
			if (startRug) {
				startRug = false;
				movement.setDecrease (false);
				Debug.Log ("leave");
			}
		}
	}

	private Color blend(Color c1, Color c2){
		c1.r *= c2.r;
		c1.g *= c2.g;
		c1.b *= c2.b;
		return c1;
	}

}
