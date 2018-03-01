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
	public Transform player;
	GameState gameState = GameState.Start;
	
	public GameState GameState{ get; set;}

	public void CompleteLevel() {
		//Debug.Log ("LEVEL WON!");	
		pauseBtn.SetActive(false);

		saveScore ();
		completeLevelUI.SetActive(true);

	}

	private void saveScore() {
		if (PlayerPrefs.GetInt ("CUR") < score)
				PlayerPrefs.SetInt ("CUR", score);
		
		if (!PlayerPrefs.HasKey ("_SCORE"))
			PlayerPrefs.SetInt ("_SCORE", score);
		else {
			if (PlayerPrefs.GetInt ("_SCORE") < score)
				PlayerPrefs.SetInt ("_SCORE", score);
		}
	}

	public void EndGame() {
		if (this.gameState != GameState.Dead) {
			
			//Debug.Log ("GAME OVER");
			//SceneManager.LoadScene ("Credits");
			//restart game
			//life -= 1;
			//scores[3- life] = score;
			//Debug.Log (score);
			saveScore ();
			if (PlayerPrefs.GetInt("LIFE") > 0) { 
				PlayerPrefs.SetInt("LIFE", PlayerPrefs.GetInt("LIFE") - 1);
				Debug.Log ("life - 1");
			} else {
				player.transform.GetComponent<playerMovement>().enabled = false;
				//FindObjectOfType<playerMovement> ().enabled = false;
				//getHighScore ();
				Debug.Log(PlayerPrefs.GetInt("LIFE"));
				this.gameState = GameState.Dead;
				SceneManager.LoadScene ("Credits");
			}
		}

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
}
