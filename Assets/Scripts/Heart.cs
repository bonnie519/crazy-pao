using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		//increase score via some UIManager
		//destroy this gameobject
		Debug.Log("you got a heart");
		PlayerPrefs.SetInt ("LIFE", PlayerPrefs.GetInt ("LIFE") + 1);
		Destroy (this.gameObject);
	}
}
