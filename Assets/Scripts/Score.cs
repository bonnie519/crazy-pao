using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	private int coinScore = 0, disScore = 0;
	public Text scoreText, heartText;
	private static int hearts = 3;

	void Start()
	{
		PlayerPrefs.SetInt ("LIFE", hearts);
	}

	// Update is called once per frame

	void Update () {
		//Debug.Log (player.position.z);
		distanceBonus();
		scoreText.text = myScore().ToString ("0");
		heartText.text = "Hearts:" + PlayerPrefs.GetInt("LIFE").ToString ();
		FindObjectOfType<GameManager>().setScore(myScore());
		Debug.Log ("Score:"+ PlayerPrefs.GetInt("LIFE"));
	}

	public int myScore()
	{
		return disScore + coinScore;
	}

	private void distanceBonus() {
		int dis = (int)(player.position.z);
		disScore = 5 * dis / 50;
	}
	public void increaseScore(int value) {
		coinScore += value;
	}

}
