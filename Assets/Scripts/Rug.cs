using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rug : MonoBehaviour {
	public Rigidbody rb;
	public float backwardForce = 70f;
	void OnTriggerEnter(Collider col)
	{
		//increase score via some UIManager
		//destroy this gameobject
		Debug.Log("you enter a rug");

	}

	void Update()
	{
		rb.AddForce (0, 0, -backwardForce * Time.deltaTime);//compatible with different frames
	}
}
