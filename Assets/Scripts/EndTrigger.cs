using UnityEngine;

public class EndTrigger : MonoBehaviour {
	public float end = 200f;
	void OnTriggerEnter() {
		Debug.Log ("you hit end");
		//should generate another path to make game endless
		//Debug.Log(PlayerPrefs.GetInt ("CUR") );
		FindObjectOfType<GameManager>().CompleteLevel ();

	}
}
