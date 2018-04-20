using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {
	public GameObject mmenu;
	public GameObject setting;
	public Text nameText;
	public Dropdown dropdown;

	void Start() {
		PlayerPrefs.SetInt ("LIFE", 3);
		PlayerPrefs.SetInt ("CUR", 0);
		PlayerPrefs.SetString ("Name", "");
		PlayerPrefs.SetInt ("DIFFICULTY", 0);
		if (!PlayerPrefs.HasKey ("Record"))
			PlayerPrefs.SetString ("Record","");
	}
	public void StartGame() {
		SceneManager.LoadScene (1);
		//Debug.Log ("menu:"+PlayerPrefs.GetInt("LIFE"));
	}

	public void ChooseLevel(int levelIndex) {
		SceneManager.LoadScene (levelIndex);		
	}

	public void Setting() {
		setting.SetActive (true);
	}
	public void MainMenu() {
		//save the setting
		PlayerPrefs.SetString("Name", nameText.text);
		PlayerPrefs.SetInt ("DIFFICULTY", dropdown.value);

		//hide setting panel ui
		setting.SetActive (false);
	}
	public void Quit() {
		Application.Quit ();
	}
}
