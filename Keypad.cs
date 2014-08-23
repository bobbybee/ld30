using UnityEngine;
using System.Collections;

public class Keypad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		float buttonWidth = Screen.width / 4;
		float buttonHeight = Screen.height / 4;

		string[] buttonLabels = new string[]{"1","2","3","4","5","6","7","8","9","#","0","ENTER"};

		for(int i = 0; i < 4; ++i) {
			for(int j = 0; j < 4; ++j) {
				if(GUI.Button(new Rect(j * buttonWidth, i * buttonHeight, buttonWidth, buttonHeight), buttonLabels[(i*4)+j])) {
					Debug.Log ( (i + 4) + j);
				}
			}
		}

	}
}
