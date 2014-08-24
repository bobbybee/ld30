using UnityEngine;
using System.Collections;

public class ElevatorExterior : MonoBehaviour {
	public string elevatorName = "elevatorPurgToHell";

	void OnCollisionEnter2D(Collision2D collision) {
		Application.LoadLevel(elevatorName);
	}
}
