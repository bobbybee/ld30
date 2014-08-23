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

	private string currentDirectory = "/";

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

		if(parts[0] == "help") return helpCommand(parts);
		else if(parts[0] == "version") return versionCommand(parts);
		else if(parts[0] == "clear") return clearCommand(parts);
		else if(parts[0] == "pwd") return pwdCommand(parts);
		else if(parts[0] == "ls") return lsCommand(parts);
		else return parts[0]+": command not found";
	}

	string helpCommand(string[] parts) {
		return "hsh (hell shell) help:\n" +
				"commands: \n"+
				"help: takes you to this help\n"+
				"version: dumps version information on shell\n"+
				"clear: clears shell window\n"+
				"pwd: dumps current working directory\n"+
				"ls: lists files in current directory";
	}

	string versionCommand(string[] parts) {
		return "hsh (hell shell) version 666.216";
	}

	string clearCommand(string[] parts) {
		output = "";
		return "";
	}

	string pwdCommand(string[] parts) {
		return currentDirectory;
	}

	string lsCommand(string[] parts) {
		if(parts.Length > 1) {
			string directory = parts[1];

			if(directory == "/") {
				return "heaven hell purgatory";
			} else if(directory == "heaven") {
				return "lolcat.png nyancat.mp4 passcodes.txt";
			} else if(directory == "hell") {
				return "punkmusic.mp3 h4x0r.1337.was.here";
			} else if(directory == "purgatory") {
				return "internalmemos.txt";
			}

			return "listing files in directory "+directory;
		} else {
			return lsCommand(new string[]{"ls", currentDirectory});
		}
	}
}
