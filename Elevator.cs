using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public string destination = "hell";
	
	void Update () {
		if(!audio.isPlaying) {
			Application.LoadLevel(destination);
		}
	}

	void OnGUI() {
		if(GUI.Button(new Rect(0, 0, 300, 100), "Skip")) {
			Application.LoadLevel(destination);
		}
	}
}
