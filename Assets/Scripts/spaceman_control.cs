using UnityEngine;
using System.Collections;

public class spaceman_control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetKey (KeyCode.LeftArrow)) {
						this.transform.Translate (-0.01f, 0, 0);
			//this.transform.Rotate (180, 0, 0);
				} else if (Input.GetKey (KeyCode.RightArrow)) {
						this.transform.Translate (0.01f, 0, 0);		
			//this.transform.Rotate (0, 0, 0);

				}



		}
}
