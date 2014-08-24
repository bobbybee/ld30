using UnityEngine;
using System.Collections;

public class GuardShutdown : CMD {
	public float timeLeft = 3;

	string advanceDestination = "heaven";
	string failDestination = "hell";

	void Start() {
		output += "A guard process (PID 1337) saw you.\nShutdown its process in 30 seconds to proceed to heaven.\nElse, you will thrown back into hell.\n";
	}

	void Update() {
		timeLeft -= Time.deltaTime;

		if(timeLeft <= 0) {
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

		if(parts[0] == "kill") {
			if(parts[1] != "-9") {
				beep();

				return "option "+parts[1]+" incorrect";
			}

			if(parts[2] != "1337") {
				beep();

				return "pid "+parts[2]+" invalid";
			}

			Application.LoadLevel(advanceDestination);

			return "Process killed";
		} else {
			beep();

			return "command "+parts[0]+" not allowed";
		}
	}
}
