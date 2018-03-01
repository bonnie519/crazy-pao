using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour {
	public void BackToMenu() {
		SceneManager.LoadScene (0);
	}
}
