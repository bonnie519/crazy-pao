using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour {
	public static bool IsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject intro;
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			if (IsPaused) {
				Resume ();
			}
			else {
				Pause ();
			}
		} */
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		IsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void Restart() {
		SceneManager.LoadScene (0);
		Time.timeScale = 1f;
	}

	public void showIntro() {
		Time.timeScale = 0f;
		intro.SetActive (true);

	}

	public void startPlay() {
		intro.SetActive (false);
		FindObjectOfType<playerName> ().enabled = true;
		Time.timeScale = 1f;
	}

}
