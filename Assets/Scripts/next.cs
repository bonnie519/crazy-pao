using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class next : MonoBehaviour {
	public Image prev;
    public GameObject player;
	public Image cur;
	public GameObject sphere, cube;
	// Use this for initialization
	void Start () {
		
	/*	this.GetComponent<Renderer> ().material.color = player.GetComponent<Renderer> ().material.color; 
		//this.gameObject.transform.position = new Vector3(-100, 30, player.transform.position.z + 200);
		this.GetComponent<MeshFilter>().mesh = player.GetComponent<MeshFilter>().mesh;
		this.gameObject.transform.position = new Vector3(-100, 30, player.transform.position.z + 200);*/
		setPlayer ();
		setPlayerHit (player);
	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<Renderer>().material.color = current.GetComponent<Renderer>().material.color;
        //			print ("col type is : " + this.GetComponent<MeshFilter> ().mesh + " " + this.GetComponent<MeshFilter> ().mesh.vertices[1]);
        //			print ("this type is: " + col.GetComponent<MeshFilter> ().mesh + " " + col.GetComponent<MeshFilter> ().mesh.vertices[1]);
        //this.GetComponent<MeshFilter>().mesh = player.GetComponent<MeshFilter>().mesh;

    }

	private int getShape(GameObject go) {
		if (go.GetComponent<MeshFilter> ().mesh.vertices [0] == sphere.GetComponent<MeshFilter> ().sharedMesh.vertices [0])
			return 0;
		else if (go.GetComponent<MeshFilter> ().mesh.vertices [0] == cube.GetComponent<MeshFilter> ().sharedMesh.vertices [0])
			return 1;
		else
			return 2;
	}
	public void setPlayer() {
		prev.color = player.GetComponent<Renderer> ().material.color; 
		//this.gameObject.transform.position = new Vector3(-100, 30, player.transform.position.z + 200);
		//this.GetComponent<MeshFilter>().mesh = player.GetComponent<MeshFilter>().mesh;
		//this.gameObject.transform.position = new Vector3(-100, 30, player.transform.position.z + 200);
		switch(getShape(player)) {
		case 0:		prev.sprite = Resources.Load<Sprite>("Sphere");
			break;
		case 1:		prev.sprite = Resources.Load<Sprite>("Cube");
			break;
		case 2:		prev.sprite = Resources.Load<Sprite>("Cylinder");
			break;
		}

	}
	public void setPlayerHit(GameObject hit) {
		cur.color = hit.GetComponent<Renderer> ().material.color; 
		//playerhitshow.GetComponent<MeshFilter>().mesh = hit.GetComponent<MeshFilter>().mesh;
		//playerhitshow.color = hit.GetComponent<Renderer> ().material.color; 
		//playerhitshow.gameObject.transform.position = new Vector3(100, 30, player.transform.position.z + 200);
		switch(getShape(hit)) {
		case 0:		cur.sprite = Resources.Load<Sprite>("Sphere");
			break;
		case 1:		cur.sprite = Resources.Load<Sprite>("Cube");
			break;
		case 2:		cur.sprite = Resources.Load<Sprite>("Cylinder");
			break;
		}
	}
}
