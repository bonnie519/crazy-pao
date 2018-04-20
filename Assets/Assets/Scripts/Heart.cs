using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {
    public GameObject FlyTextObj_life;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
        GameObject fly_life = Instantiate(FlyTextObj_life);

        fly_life.transform.position = col.transform.position + new Vector3(0, 0, 15);
        Destroy(fly_life, 1.2f);
        //increase score via some UIManager
        //destroy this gameobject
        Debug.Log("you got a heart");
		PlayerPrefs.SetInt ("LIFE", PlayerPrefs.GetInt ("LIFE") + 1);
		Destroy (this.gameObject);
	}
}
