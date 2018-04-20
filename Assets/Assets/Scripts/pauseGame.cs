using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseGame : MonoBehaviour {

	//public Rigidbody rb;
	//public GameManager gameManager;
	public Text myText;
	public bool paused;
	void start() {
		paused = false;
	}
	
	public void Pause() {
		paused = !paused;
		if (paused) {
			Time.timeScale = 0;
			myText.text = "RESUME";
		} else {
			Time.timeScale = 1;
			myText.text = "PAUSE";
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
