using UnityEngine;

public class Coin : MonoBehaviour
{
	public float rotateSpeed = 50f;
	public int scorePoints = 1;
    public GameObject FlyTextObj_score;


    void Update()
	{
		transform.Rotate (0, 0, 3);
	}

	void OnTriggerEnter(Collider col)
	{
        GameObject fly_score = Instantiate(FlyTextObj_score);

        fly_score.transform.position = col.transform.position + new Vector3(0, 0, 10);
        Destroy(fly_score, 1.0f);
        //increase score via some UIManager
        //destroy this gameobject
        //Debug.Log("you hit a coin");
        FindObjectOfType<Score>().increaseScore (1);
		Destroy (this.gameObject);
	}
}


