using UnityEngine;
using System.Collections;

public class spaceman_code : MonoBehaviour {

	Vector3 rightScale;
	Vector3 leftScale;

	// Use this for initialization
	void Start () {
		rightScale = transform.localScale;
		Vector3 vec = transform.localScale;
		vec.x *= -1;
		leftScale = vec;
	}

	// Update is called once per frame
	void Update () {


				if (Input.GetKey (KeyCode.LeftArrow)) {
						transform.Translate (-0.1f, 0.0f, 0.0f);
						transform.localScale = leftScale;
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						transform.Translate (0.1f, 0.0f, 0.0f);		
						transform.localScale = rightScale;
				}
	}
}
