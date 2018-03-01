using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credit : MonoBehaviour {
	//public Score score;
	public Text scoreText;
	void Start() {
		scoreText.text += PlayerPrefs.GetInt ("CUR").ToString();
		//Debug.Log (FindObjectOfType<GameManager>().getScore());

	}
	public void Quit() {
		Debug.Log ("QUIT");
		Application.Quit ();
	}
	public void Restart() {
		PlayerPrefs.SetInt ("CUR", 0);
		SceneManager.LoadScene (0);
		PlayerPrefs.SetInt ("LIFE", 3);
	}
}
