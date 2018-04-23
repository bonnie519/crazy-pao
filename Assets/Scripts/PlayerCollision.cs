using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollision : MonoBehaviour {
	Color[] colors = {Color.black, Color.blue,Color.red, new Color(233f/255f,101f/255f,191f/255f,1f)};
 	int index = -1;
	public playerMovement movement;
	public float restartDelay = 1f;


    public GameObject FlyTextObj1;
    public Transform CameraTrans;

    public GameObject FlyTextObj2;

    public GameObject FlyTextObj_death;
	public GameObject sphere;
    private void Restart() {
		movement.enabled = true;
		//movement.setForce (200f,0);
	}
	public Color getNextColor() {
		//if (index == -1)
		//	return this.GetComponent<Renderer> ().material.color;
		return colors [(index+1)% 4];
	}

	void OnTriggerEnter(Collider col) {
        

        if (col.tag == "Obstacle") {

			FindObjectOfType<next> ().setPlayerHit (col.gameObject);
            //movement.enabled = false;
			FindObjectOfType<next> ().setPlayer ();
            // if has 0 life left, end game
            if ((this.GetComponent<MeshFilter> ().mesh.vertices[0] == col.GetComponent<MeshFilter> ().mesh.vertices[0]) || 
				col.gameObject.GetComponent<Renderer> ().material.color == this.GetComponent<Renderer> ().material.color) {
				//Debug.Log ("same color"+this.GetComponent<Renderer> ().material.color);
				//col.transform.GetComponent<BoxCollider> ().isTrigger = true;
//				index = (index + 1) % colors.Length;
				if ((this.GetComponent<MeshFilter> ().mesh.vertices [0] == col.GetComponent<MeshFilter> ().mesh.vertices [0]) &&
				    col.gameObject.GetComponent<Renderer> ().material.color == this.GetComponent<Renderer> ().material.color) {
					FindObjectOfType<Score> ().increaseScore (15);

                    GameObject fly2 = Instantiate(FlyTextObj2);

                    fly2.transform.position = col.transform.position + new Vector3(0, 0, 15);
                    Destroy(fly2, 1.2f);


                } else {
					FindObjectOfType<Score> ().increaseScore (3);

                    GameObject fly1 = Instantiate(FlyTextObj1);

                    fly1.transform.position = col.transform.position + new Vector3(0, 0, 15);
                    Destroy(fly1, 1.2f);
                }

               

            } else {
                GameObject fly_death = Instantiate(FlyTextObj_death);
                fly_death.transform.position = col.transform.position + new Vector3(0, 0, 15);
                Destroy(fly_death, 1.2f);

                movement.rb.velocity = new Vector3(0, 0, 0);
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 5f, this.gameObject.transform.position.z); ;
                CameraTrans.DOShakePosition(0.4f, Vector3.up, 10, 20);
                CameraTrans.DOShakePosition(0.4f, Vector3.back, 5, 10).OnComplete(ReposCamera);

				//this.GetComponent<Renderer> ().material.color = blend(this.GetComponent<Renderer> ().material.color,
				//collision.collider.gameObject.GetComponent<Renderer> ().material.color);
//				FindObjectOfType<Score> ().increaseScore (-30);
//				if (FindObjectOfType<Score> ().myScore() < 0) {
//					FindObjectOfType<Score> ().increaseScore
//				
//				} 
				Time.timeScale = 0;
				if (PlayerPrefs.GetInt("LIFE") >= 0) {
					Time.timeScale = 1;
				}
				FindObjectOfType<GameManager> ().EndGame ();
			}
			this.GetComponent<Renderer> ().material.color = col.GetComponent<Renderer> ().material.color;
//			print ("col type is : " + this.GetComponent<MeshFilter> ().mesh + " " + this.GetComponent<MeshFilter> ().mesh.vertices[1]);
//			print ("this type is: " + col.GetComponent<MeshFilter> ().mesh + " " + col.GetComponent<MeshFilter> ().mesh.vertices[1]);
			this.GetComponent<MeshFilter> ().mesh = col.GetComponent<MeshFilter> ().mesh;
			//Debug.Log (col.GetComponent<MeshFilter>().mesh);

			if (col.transform.localScale.y < 2f) {//if not moving obstacle, scale as the collider's half
				//Debug.Log(this.gameObject.transform.localScale);
				//Debug.Log(col.transform.localScale);
				this.gameObject.transform.localScale = col.transform.localScale * 0.5f;
			} else
				this.gameObject.transform.localScale = new Vector3 (1,1,1);
			// else
			//restart game
			Destroy(col.gameObject);
		}
	}

	private Color blend(Color c1, Color c2){
		c1.r *= c2.r;
		c1.g *= c2.g;
		c1.b *= c2.b;
		return c1;
	}

    void ReposCamera()
    {
        CameraTrans.localPosition = new Vector3(0, 1.8f, -3.17f);
    }
}
