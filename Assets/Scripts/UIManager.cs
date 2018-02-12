using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
	public Transform player;
	public Text scoreText;
	public Text statusText;
	private float score;

	// Use this for initialization
	void Start () {

	}

	public void SetScore(float score) {
		this.score = score;
	}

	private void updateScore() {
		scoreText.text = score.ToString ();	
	}

	public void updateStatus(string status) {
		statusText.text = status;
	}

	public void increaseScore(float incr) {
		score += incr;
		updateScore ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (player.position.z);
		scoreText.text = player.position.z.ToString("0");
	}
}

