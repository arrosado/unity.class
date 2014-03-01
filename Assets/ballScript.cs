using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class ballScript : MonoBehaviour {

	public Transform particles;

	public Rigidbody bullet;


	public const float jumpForce = 100.0f;

	private const float ZERO = 0.0f;
	private const float SPEED = 200.0f;
	private const float BULLET_FORCE = 1000.0f;
	private const int BULLET_MAX_LIFETIME = 300;
	private const int MAX_CONCURRENT_BULLETS = 10;
	private IList<Bullet> bullets = new List<Bullet> ();

	private class Bullet 
	{
		public DateTime StartDate { get; set; }
		public Rigidbody BulletBody { get; set; }
	}

	void Update () {

		float acceleration = Time.deltaTime * SPEED;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate(ZERO, -1.0f * acceleration, ZERO, Space.Self);		
		} 

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate(ZERO, 1.0f * acceleration, ZERO, Space.Self);
		} 

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate(ZERO, ZERO, 1.0f * acceleration, Space.World);
		} 

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate(ZERO, ZERO, -1.0f * acceleration, Space.World);
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			rigidbody.AddForce(0, jumpForce, 0, ForceMode.Impulse); 		
		}

		if (Input.GetKey(KeyCode.X))
		{
			if (bullets.Count < MAX_CONCURRENT_BULLETS){
				Vector3 bulletSpawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 10);
				Rigidbody tempBullet = Instantiate(bullet, bulletSpawnPosition, Quaternion.identity) as Rigidbody;
				tempBullet.AddRelativeForce(Vector3.forward * BULLET_FORCE, ForceMode.Impulse);

				bullets.Add(new Bullet() { BulletBody = tempBullet, StartDate = DateTime.Now });
			}
		}

		for (int i = 0; i < bullets.Count; i++) {

			Bullet b = bullets[i];
			TimeSpan lifetime = DateTime.Now.Subtract(b.StartDate);

			if (lifetime.Milliseconds > BULLET_MAX_LIFETIME){
				Destroy(b.BulletBody.gameObject);
				bullets.Remove(b);
			}

		}

	}

	void OnCollisionEnter(Collision collider)
	{
		print ("Colliding with : "  + collider.gameObject.name);

		if (collider.gameObject.name != "Plane" && 
		    collider.gameObject.name != "bullet(Clone)") {
			collider.gameObject.renderer.material.color = Color.red;
			Instantiate(particles, collider.gameObject.transform.position, Quaternion.identity);	
		}
	}
}
	
