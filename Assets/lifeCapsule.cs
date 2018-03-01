using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeCapsule: MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(3, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        //increase score via some UIManager
        //destroy this gameobject
        Debug.Log("you got a heart");
        PlayerPrefs.SetInt("LIFE", PlayerPrefs.GetInt("LIFE") + 1);
        Destroy(this.gameObject);
    }
}
