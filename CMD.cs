using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CMD : MonoBehaviour {

	public Rect promptLocation = new Rect(10, 10, 20, 30);
	public string prompt = "> ";

	public Rect cmdPrompt = new Rect(30, 10, 1790, 30);
	public Rect enterButton = new Rect(1830, 10, 80, 30);
	private string command = "";

	public Rect outputBox = new Rect(10, 50, 1900, 1010);
	protected string output = "";

	public Vector2 nativeResolution = new Vector2(1920, 1080);

	public Font myFont;

	private string currentDirectory = "/";

	private Dictionary<string, string> filesystem = new Dictionary<string, string>{
		{"/heaven/passcodes.txt", "Old passcode: 1234\n\nApparently, a hacker bruteforced our passcode with a dictionary attack.\nTherefore, here is the new passcode:\n\n"+GameGlobals.passcode},
		{"/hell/h4x0r.1337.was.here", "h37 1 4wn3d ur s3c4r1ty 1m s00 1337"},
		{"/purgatory/internalmemos.txt", "Supervisor? When I was evaluating someone's life, they received a negative verdict.\nWeird thing is, they went over to the Heaven door, and tried to get in.\nObviously, we have good security, but it's just suspicious.\n~Life Evaluator\n\nAlright, I'm looking into it. They seem to be in Hell, so it doesn't matter much now.\n~Supervisor"},
		{"/hell/prisonlist.db", "ID | Name\n0 | John the Ripper\n1 | Sabu\n2 | #ffffffhat\n3 | The Dev of This Game\n4 | The Artist of This Game\n5 | Random Guy Making Inside Jokes For This Game\n"}
	};

	void ExecuteCommand() {
		output = prompt + command + "\n" + EvaluateCommand(command) + "\n" + output;
		command = "";

	}

	void OnGUI() {
		// scale properly

		GUI.matrix = Matrix4x4.TRS (Vector3.zero, Quaternion.identity, new Vector3(Screen.width / nativeResolution.x, Screen.height / nativeResolution.y, 1));
		GUI.skin.label.font = GUI.skin.box.font = GUI.skin.button.font = GUI.skin.textArea.font = GUI.skin.textField.font = myFont;

		GUI.Label(promptLocation, prompt);
		 
		command = GUI.TextField(cmdPrompt, command);


		if(GUI.Button(enterButton, "ENTER") || (Event.current.isKey && (Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter) ) ) {
			ExecuteCommand();
		}

		GUI.TextField(outputBox, output);
	
	}

	protected void beep() {
		audio.Play();
	}

	protected virtual string EvaluateCommand(string command) {
		string[] parts = command.Split (' ');

		if(parts[0] == "help") return helpCommand(parts);
		else if(parts[0] == "version") return versionCommand(parts);
		else if(parts[0] == "clear") return clearCommand(parts);
		else if(parts[0] == "exit") return exitCommand(parts);
		else if(parts[0] == "pwd") return pwdCommand(parts);
		else if(parts[0] == "ls") return lsCommand(parts);
		else if(parts[0] == "cd") return cdCommand(parts);
		else if(parts[0] == "cat") return catCommand(parts);
		else if(parts[0] == "tp") return tpCommand(parts);
		else {
			beep();
			return parts[0]+": command not found";
		}
	}

	string helpCommand(string[] parts) {
		return "hsh (hell shell) help:\n" +
				"commands: \n"+
				"help: takes you to this help\n"+
				"version: dumps version information on shell\n"+
				"clear: clears shell window\n"+
				"exit: exits the shell\n"+
				"pwd: dumps current working directory\n"+
				"ls: lists files in current directory\n"+
				"cd: change directory\n"+
				"cat: dumps a file or stream to stdout\n"+
				"tp: its a mystery\n";
	}

	string versionCommand(string[] parts) {
		return "hsh (hell shell) version 666.216";
	}

	string clearCommand(string[] parts) {
		output = "";
		return "";
	}

	string exitCommand(string[] parts) {
		Application.LoadLevel("control room");
		return "";
	}

	string pwdCommand(string[] parts) {
		return currentDirectory;
	}

	string lsCommand(string[] parts) {
		if(parts.Length > 1) {
			string directory = parts[1];

			if(!directory.StartsWith(currentDirectory)) {
				directory = currentDirectory + directory;
			}

			if(directory == "/") {
				return "heaven hell purgatory";
			} else if(directory == "/heaven") {
				return "lolcat.png nyancat.mp4 passcodes.txt";
			} else if(directory == "/hell") {
				return "punkmusic.mp3 h4x0r.1337.was.here prisonlist.db";
			} else if(directory == "/purgatory") {
				return "internalmemos.txt";
			}

			beep();
			return "directory "+directory+" not found. try absolute paths?";
		} else {
			return lsCommand(new string[]{"ls", currentDirectory});
		}
	}

	string cdCommand(string[] parts) {
		if(parts[1] == ".." || parts[1] == "/") {
			currentDirectory = "/";
		} else if(parts[1] == "hell" || parts[1] == "heaven" || parts[1] == "purgatory") {
			currentDirectory = "/"+parts[1];
		} else if(parts[1] == "/hell" || parts[1] == "/heaven" || parts[1] == "/purgatory") {
			currentDirectory = parts[1];
		} else {
			beep ();
			return "directory not found";
		}

		return "changed directory to "+parts[1];
	}

	string catCommand(string[] parts) {
		if(parts.Length > 1) {
			string file = parts[1];

			if(!file.StartsWith(currentDirectory)) {
				file = currentDirectory + "/"+ file;
			}

			if(file == "/heaven/lolcat.png" || file == "/heaven/nyancat.mp4" || file == "/hell/punkmusic.mp3") {
				beep ();
				return "Format error: input binary file cannot be redirected to stdout";
			} else if(file == "/heaven/passcodes.txt" || file == "/hell/h4x0r.1337.was.here" || file == "/purgatory/internalmemos.txt" || file == "/hell/prisonlist.db") {
				return filesystem[file];
			} else {
				beep ();
				return "file not found. try absolute paths?";
			}
		} else {
			beep ();
			return "Pipe error: cannot redirect stdin to stdout";
		}
	}

	string tpCommand(string[] parts) {
		if(parts.Length < 2) {
			beep ();
			return "usage: tp [prisoner id] [location]";
		} else {
			string prisonerId = parts[1];
			string location = parts[2];

			if(prisonerId != "2") {
				beep();
				return "permission denied: no access to prisoner id";
			} else if(location == "heaven") {
				beep ();
				return "permission denied: no tp to "+location+" from hell";
			} else if(location != "hell" && location != "purgatory") {
				beep ();
				return "unknown location: "+location;
			} else {
				Application.LoadLevel(location);
				return "";
			}
		}
	}
}
