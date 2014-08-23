using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Keypad : MonoBehaviour {

	public GUIStyle inputStyle;

	List<int> numbers = new List<int>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUI.Label(new Rect(0, 0, Screen.width, Screen.height / 5), string.Join("", numbers.Select(x=>x.ToString()).ToArray()), inputStyle);

		float buttonWidth = Screen.width / 3;
		float buttonHeight = Screen.height / 5;

		string[] buttonLabels = new string[]{"1","2","3","4","5","6","7","8","9","BACKSPACE","0","ENTER"};

		for(int i = 0; i < 4; ++i) {
			for(int j = 0; j < 3; ++j) {
				if(GUI.Button(new Rect(j * buttonWidth, (i+1) * buttonHeight, buttonWidth, buttonHeight), buttonLabels[(i*3)+j])) {
					int index = (i * 3) + j;

					if(index < 9) {
						numbers.Add (index + 1);
					} else if (index == 10) {
						numbers.Add (0);
					} else if(index == 9) {
						numbers.Remove(numbers.Last());
					} else if(index == 11) {
						int trying = 0;
						int powIndex = 0;

						for(int numIndex = numbers.Count - 1; numIndex >= 0; --numIndex) {
							trying += numbers[numIndex] * (int) Mathf.Pow(10, (float) powIndex);

							powIndex++;
						}

						Debug.Log (trying);
					} else {
						Debug.Log (buttonLabels[index]);
					}
				}
			}
		}

	}
}
