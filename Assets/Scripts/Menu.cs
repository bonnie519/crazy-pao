using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene (2);		
		PlayerPrefs.SetInt ("LIFE", 3);
		Debug.Log ("menu:"+PlayerPrefs.GetInt("LIFE"));
	}

	public void ChooseLevel(int levelIndex) {
		SceneManager.LoadScene (levelIndex);		
	}

	public void Setting() {
		SceneManager.LoadScene (1);
	}
}
