using UnityEngine;
using System.Collections;

public class ElevatorExterior : MonoBehaviour {
	public string elevatorName = "elevatorPurgToHell";

	void OnCollisionEnter2D(Collision2D collision) {
		if(elevatorName == "keypad" && GameGlobals.heavenUnlocked) {
			Application.LoadLevel("heaven");
			return;
		}

		Application.LoadLevel(elevatorName);
	}
}
