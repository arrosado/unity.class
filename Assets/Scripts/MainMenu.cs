using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {
	public Texture backgroundTexture;

	void OnGUI()
	{
		// Display our background texture.
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), this.backgroundTexture);

		float left = Screen.width * .5f;
		float top  = Screen.height * .5f;
		float width = Screen.width * .5f;
		float height = Screen.height * .1f;

		float lastPos = 0;

		foreach (var menuText in (new List<string>() { "Play Game", "Level1", "Level2", "Level3" })) {

			if (GUI.Button (new Rect (left, top + (lastPos += height), width, height), menuText)) {
				print ("Clicked " + menuText);		
			}

		}

	}
}
