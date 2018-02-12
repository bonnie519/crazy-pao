using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	/*void Awake()
	{
		if (TreeInstance == null) {
			TreeInstance = this;
		} else {
			DestroyImmediate (this);
		}
	}
	private static GameManager instance;
	public static GameManager Instance
	{
		get
		{
			if (instance == null) {
				instance = new GameManager ();
			}
			return instance;
		}
	}*/
	//bool gameHasEnded = false;
	private static int life = 3;
	public float restartDelay = 2f;
	public static int score = 0;
	public GameObject completeLevelUI;
	public GameObject pauseBtn;
	static int[] scores = new int[3];
	GameState gameState = GameState.Start;
	
	public GameState GameState{ get; set;}

	public void CompleteLevel() {
		//Debug.Log ("LEVEL WON!");	
		pauseBtn.SetActive(false);
		//scores[2- life] = score;
		//Debug.Log (score);

		saveScore ();
		completeLevelUI.SetActive(true);

	}
	private void saveScore() {
		PlayerPrefs.SetInt("CUR", score);
		if (!PlayerPrefs.HasKey ("_SCORE"))
			PlayerPrefs.SetInt ("_SCORE", score);
		else {
			if (PlayerPrefs.GetInt ("_SCORE") < score)
				PlayerPrefs.SetInt ("_SCORE", score);
		}
	}
	public void EndGame() {
		if (this.gameState != GameState.Dead) {
			this.gameState = GameState.Dead;
			Debug.Log ("GAME OVER");
			//SceneManager.LoadScene ("Credits");
			//restart game
			life -= 1;
			scores[2- life] = score;
			//Debug.Log (score);

			if (life > 0) {
				this.gameState = GameState.Start;
				Invoke ("Restart", restartDelay);
			} else {
				getHighScore ();
				saveScore ();
				SceneManager.LoadScene ("Credits");
				life = 3;
			}
		}

	}
	private void getHighScore() {

		for (int i = 0; i < 3; i++) {
			//Debug.Log ("score "+ scores [i]);
			if (scores [i] > score)
				score = scores [i];
		}
		Debug.Log (score);
	}
	public void setScore(int value) {
		score = value;
	}
	public int getScore() {
		return score;
	}
	public void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);		
	}
	void Pause() {
		//SceneManager.
	}
}
