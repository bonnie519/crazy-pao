using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	public Rigidbody rb;
	//public GameObject introText;
	public float forwardForce;
	public float slidewayForce;
	//public Swipe swipe;
	private bool isDragging = false, decrease = false;
	private Vector2 startTouch, swipeDelta;
	public float decreaseRate = 0.8f;
	float speed = 0.0f;
	bool preSwipeUp = false;
	float x_pos = 0.0f;
	//public GameObject layerObject;
	// Use this for initialization
	void Start () {
		
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			//Instantiate (introText);
			FindObjectOfType<playerName>().enabled = false;
			FindObjectOfType<PauseResume> ().showIntro ();

		}
		switch(PlayerPrefs.GetInt("DIFFICULTY")){
		case 0:
			{
				forwardForce = 900f;
				slidewayForce = 120f;
			}
			break;
		case 1:
			{
				forwardForce = 1000f;
				slidewayForce = 150f;
			}
			break;
		case 2:
			{
				forwardForce = 1200f;
				slidewayForce = 200f;
			}
			break;
		};

	}
	private bool checkSwipe ()
	{
		bool res = false;
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
					res = true;
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
		if (decrease) {
			int x_axis = 0;
			if (Input.acceleration.x > 0.05 || Input.GetKey("d"))
				x_axis = 1;
			if (Input.acceleration.x < -0.05 || Input.GetKey("a"))
				x_axis = -1;
			/*if (rb.velocity.z > 1.25f) {
				float tmp = rb.velocity.z * (1 - decreaseRate);
				rb.velocity = new Vector3(x_axis * tmp, 0, tmp);
				//1 - decreaseRate;
			} else {*/
			rb.velocity = new Vector3(x_axis * this.speed, 0, this.speed);
			//}
			//transform.Translate (x_axis * rb.velocity.z * Time.deltaTime,0,0);
			//Debug.Log ("decrease" + x_axis+" "+ this.speed);
		} else {
			rb.AddForce (0,0,forwardForce * Time.deltaTime);//compatible with different frames
			//transform.Translate(Input.acceleration.x, 0, 0);
			float offset = Input.acceleration.x;
			x_pos = rb.position.x + offset;
			if (x_pos >= -7f && x_pos <= 7f)
				transform.Translate(0, -offset, 0);//change due to rotation of player transform
			bool cur = checkSwipe () || Input.GetKey("w");

			if (preSwipeUp == false) {
				
				if (cur == true) {
					rb.AddForce (0, 4 * slidewayForce * Time.deltaTime, 0, ForceMode.VelocityChange);
				}
			}
			preSwipeUp = cur;
			if (Input.GetKey ("a"))
				rb.AddForce (-slidewayForce * Time.deltaTime, 0, 0,ForceMode.VelocityChange);
			if (Input.GetKey ("d"))
				rb.AddForce (slidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
			//Debug.Log (rb.velocity.z);
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
		float tmp = rb.velocity.z;
		this.speed = tmp * decreaseRate;
	}
	public void startPlay()
	{
		Time.timeScale = 1f;
	}
}


