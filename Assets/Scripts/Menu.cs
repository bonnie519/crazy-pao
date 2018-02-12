using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public void StartGame() {
		SceneManager.LoadScene (2);		
	}

	public void ChooseLevel(int levelIndex) {
		SceneManager.LoadScene (levelIndex);		
	}

	public void Setting() {
		SceneManager.LoadScene (1);
	}
}
