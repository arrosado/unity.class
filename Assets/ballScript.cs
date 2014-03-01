using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {

	public const float speed = 200.0f;
	public const float ZERO = 0.0f;
	public const float jumpForce = 100.0f;

	void Update () {

		float acceleration = Time.deltaTime * speed;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate(ZERO, -1.0f * acceleration, ZERO, Space.Self);		
		} 

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate(ZERO, 1.0f * acceleration, ZERO, Space.Self);
		} 

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(ZERO, ZERO, 1.0f * acceleration, Space.Self);
		} 

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(ZERO, ZERO, -1.0f * acceleration, Space.Self);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse); 		
		}
	}

	void OnCollisionEnter(Collision collider)
	{
		if (collider.gameObject.name != "Plane")
			collider.gameObject.renderer.material.color = Color.red;
	}
}
	
