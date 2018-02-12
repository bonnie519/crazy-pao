using UnityEngine;

public class EndTrigger : MonoBehaviour {

	void OnTriggerEnter() {
		Debug.Log ("you hit end");
		//should generate another path to make game endless
		FindObjectOfType<GameManager>().CompleteLevel ();

	}
}
