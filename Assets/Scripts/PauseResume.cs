using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour {
	public static bool IsPaused = false;

	public GameObject pauseMenuUI;

	// Use this for initialization
	void Start () {
		//pauseMenuUI.SetActive (false);
	}
	
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
		Debug.Log ("resume");
	}

	public void Pause(){
		Debug.Log ("pause");
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void Restart() {
		SceneManager.LoadScene (0);
		Time.timeScale = 1f;
	}
}
