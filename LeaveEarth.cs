using UnityEngine;
using System.Collections;

public class LeaveEarth : MonoBehaviour {
	void OnGUI() {
		if(GUI.Button(new Rect(0, 0, 100, 100), "Back")) {
			Application.LoadLevel("purgatory");
		}
	}
}
