 using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public Rect startLocation;
	public Rect instructionsLocation;
	public Rect fullscreenLocation;

	public Font myFont;

	void OnGUI() {
	

		GUI.skin.label.font = GUI.skin.box.font = GUI.skin.button.font = GUI.skin.textArea.font = GUI.skin.textField.font = myFont;

		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3 ((float) Screen.width / 1920, (float) Screen.height / 1080, 1)); 

		if(GUI.Button (startLocation, "Play!") ) {
			if(Application.isWebPlayer) Screen.fullScreen = true;
			Application.LoadLevel("purgatory");
		}

		if(GUI.Button(instructionsLocation, "Instructions") ) {
			Application.LoadLevel ("instructions");
		}

		/*if(GUI.Button (fullscreenLocation, "Play Fullscreen") ) {
			Screen.fullScreen = true;
			Application.LoadLevel("purgatory");
		}*/

	}
}
