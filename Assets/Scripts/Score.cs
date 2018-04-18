﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour {

	public Transform player;
	private int coinScore = 0;
	public Text scoreText, heartText;
	//private static int hearts = 3;
	public Image nextColor;
	public Text levelText;
	void Start()
	{
		//PlayerPrefs.SetInt ("LIFE", hearts);
		coinScore = PlayerPrefs.GetInt("CUR");
		//init = player.GetComponent<Renderer> ().material.color;
		//nextColor.color = init;
		levelText.text += " " + SceneManager.GetActiveScene().buildIndex.ToString();
	}

	// Update is called once per frame

	void Update () {
		//Debug.Log (player.position.z);
		if (FindObjectOfType<GameManager>().GameState == GameState.Dead) return;
		scoreText.text = myScore().ToString ("0");
		heartText.text = PlayerPrefs.GetInt("LIFE").ToString ();
		nextColor.color = player.GetComponent<PlayerCollision> ().getNextColor ();
		//nextColor = player.GetComponent<PlayerCollision> ().getNextColor ();
		FindObjectOfType<GameManager>().setScore(myScore());
		//Debug.Log ("Score:"+ PlayerPrefs.GetInt("LIFE"));
	}

	public int myScore()
	{
		return coinScore;
	}

	/*private void distanceBonus() {
		int dis = (int)(player.position.z);
		disScore = 5 * dis / 50;
	}*/
	public void increaseScore(int value) {
		coinScore += value;
	}

}
