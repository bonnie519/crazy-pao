using UnityEngine;

public class playerMovement : MonoBehaviour {

	public Rigidbody rb;

	public float forwardForce = 1500f;
	public float slidewayForce;
	//public Swipe swipe;
	private bool isDragging = false, decrease = false;
	private Vector2 startTouch, swipeDelta;
	public float decreaseRate = 0.4f;
	//public GameObject layerObject;
	// Use this for initialization
	void Start () {
		//Debug.Log ("Hello!");
		//rb.useGravity = false;
		//rb.AddForce(0,200,500);
		forwardForce = 1500f;
		slidewayForce = 100f;
	}
	private int checkSwipe ()
	{
		int res = -1;
		//swipeL = swipeR = swipeU = false;
		//get input
		if (Input.touches.Length > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				isDragging = true;
				//tap = true;
				startTouch = Input.touches [0].position;
			} else if (Input.touches [0].phase == TouchPhase.Ended ||
				Input.touches [0].phase == TouchPhase.Canceled) {
				isDragging = false;
				Reset ();
			}
		}

		//cal the distance
		swipeDelta = Vector2.zero;
		if (isDragging) {
			if (Input.touches.Length > 0)
				swipeDelta = Input.touches [0].position - startTouch;
			//else if (Input.touches)
		}

		if (swipeDelta.magnitude > 20f) {
			float x = swipeDelta.x;
			float y = swipeDelta.y;
			if (Mathf.Abs (x) < Mathf.Abs (y)) {
				if (y > 0) {
					res = 2;
				}
			}
			Reset ();

		}
		return res;
	}
	private void Reset() {
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
	}
	// Update is called once per frame
	void FixedUpdate () {
		/*foreach (Transform child in layerObject.transform) {
			if (child.gameObject.GetComponent<Renderer> ().material.color == this.GetComponent<Renderer> ().material.color) {
				child.transform.GetComponent<BoxCollider> ().isTrigger = true;
			} else {
				child.transform.GetComponent<BoxCollider> ().isTrigger = false;
			}
		}*/
		if (decrease) {
			//Debug.Log (rb.velocity.z);
			if (rb.velocity.magnitude > 5f)
				rb.velocity -= rb.velocity * decreaseRate;
		} else {
			rb.AddForce (0, 0, forwardForce * Time.deltaTime);//compatible with different frames
			//transform.Translate(Input.acceleration.x, 0, 0);
			int swipe = checkSwipe ();
			if (Input.GetKey ("a"))
				rb.AddForce (-slidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			if (Input.GetKey ("d"))
				rb.AddForce (slidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			if (swipe == 2 || Input.GetKey ("w")) {
				rb.AddForce (0, slidewayForce * Time.deltaTime, 0, ForceMode.VelocityChange);
			}
		}
		if (rb.position.y < -1f || rb.position.y > 500f) {
			this.enabled = false;
			//FindObjectOfType<GameManager> ().EndGame ();
			if (PlayerPrefs.GetInt ("LIFE") > 0) {
				int tmpLife = PlayerPrefs.GetInt ("LIFE");
				FindObjectOfType<GameManager> ().Restart ();
				PlayerPrefs.SetInt ("LIFE", tmpLife - 1);
			} else
				FindObjectOfType<GameManager> ().EndGame ();
		}
		if (PlayerPrefs.GetInt("LIFE") > 0 && rb.position.z > FindObjectOfType<EndTrigger> ().end)
			FindObjectOfType<GameManager> ().CompleteLevel ();
		//Debug.Log (rb.velocity.z);
	}
	public void setDecrease(bool value) {
		decrease = value;
	}
		
}


