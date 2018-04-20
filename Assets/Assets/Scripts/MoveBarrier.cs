using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBarrier : MonoBehaviour {
	public bool StartLeft;
	public float time;
	public float ChangeDirection;
	public float moveSpeed;

	void Update()
	{
		time += Time.deltaTime;
		if (time >= ChangeDirection)
		{
			StartLeft = !StartLeft;
			time = 0;            
		}
		if (StartLeft)
			transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		else
			transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
	}
}
