using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Transform player;
	private int coinScore = 0, disScore = 0;
	public Text scoreText;
	// Update is called once per frame
	void Update () {
		//Debug.Log (player.position.z);
		distanceBonus();
		scoreText.text = myScore().ToString ("0");
		FindObjectOfType<GameManager>().setScore(myScore());
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
