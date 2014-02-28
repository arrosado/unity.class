using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
				if (Input.GetKey (KeyCode.Space) == true) {
						transform.Translate (0, 1, 0, Space.World);
				}
				if (Input.GetKey (KeyCode.UpArrow) == true)
						transform.Rotate (0, 0, 1, Space.Self);
				if (Input.GetKey (KeyCode.DownArrow) == true)
						transform.Rotate (0, 0, -1, Space.Self);

				if (Input.GetKey (KeyCode.RightArrow) == true)
			transform.Rotate (0, -1, 0, Space.Self);
				if (Input.GetKey (KeyCode.LeftArrow) == true)
			transform.Rotate (0, 1, 0, Space.Self);
				
				transform.Translate (0, 1, 0, Space.Self);
		}

	void OnCollisionEnter(Collision collision)
	{
		foreach (var contact in collision.contacts) {
			Destroy(gameObject);
		}
	}

}
