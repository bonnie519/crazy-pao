using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

	public void LoadNextLevel() {
		//Debug.Log ("Scene:" + SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
