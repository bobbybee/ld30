using UnityEngine;
using System.Collections;

public class CMD : MonoBehaviour {

	public Rect promptLocation;
	public string prompt = "> ";

	public Rect cmdPrompt;
	public Rect enterButton;
	private string command = "";

	public Rect outputBox;
	private string output = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Label(promptLocation, prompt);

		command = GUI.TextField(cmdPrompt, command);

		if(GUI.Button(enterButton, "ENTER") || (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.Return) ) {
			output = prompt + command + "\n" + EvaluateCommand(command) + "\n" + output;
			command = "";
		}

		GUI.TextField(outputBox, output);
	}

	string EvaluateCommand(string command) {
		string[] parts = command.Split (' ');

		return parts[0]+" not found";
	}
}
