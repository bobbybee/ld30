using UnityEngine;
using System.Collections;

public class GuardShutdown : CMD {
	public float timeLeft = 30;

	string failDestination = "hell";

	bool gaurdSlayed = false;

	void Start() {
		output += "A guard process (PID 1337) saw you.\nShutdown its process in 30 seconds to proceed to heaven.\nElse, you will thrown back into hell.\n";
	}

	void Update() {
		timeLeft -= Time.deltaTime;

		if(timeLeft <= 0 && !gaurdSlayed) {
			beep ();
			Application.LoadLevel(failDestination);
		}
	}

	protected override string EvaluateCommand(string cmd) {
		string[] parts = cmd.Split(' ');

		if(parts.Length < 2) {
			beep();

			return "not enough options";
		}

		if(parts[0] == "kill" && !gaurdSlayed) {
			if(parts[1] != "-9") {
				beep();

				return "option "+parts[1]+" incorrect";
			}

			if(parts[2] != "1337") {
				beep();

				return "pid "+parts[2]+" invalid";
			}

			gaurdSlayed = true;

			return "Process killed\nYou have access to the central servers.\nYou now have global teleport access.\n";
		} else if(parts[0] == "tp" && gaurdSlayed) {
			if(parts.Length < 2) {
				beep ();
				return "not enough options";
			}

			if(parts[1] != "2") {
				beep ();
				return "wrong prisoner id";
			}

			if(parts[2] != "heaven" && parts[2] != "hell" && parts[2] != "purgatory") {
				beep ();
				return "unknown location";
			}

			Application.LoadLevel(parts[2]);

			return "Teleporting...";
		} else {
			beep();

			return "command "+parts[0]+" not allowed";
		}
	}
}
