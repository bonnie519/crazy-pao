using UnityEngine;

public class EndTrigger : MonoBehaviour {
	public float end = 195.3f;
	void OnTriggerEnter() {
		Debug.Log ("you hit end");
		//should generate another path to make game endless
		FindObjectOfType<GameManager>().CompleteLevel ();

	}
}
