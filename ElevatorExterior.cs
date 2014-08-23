using UnityEngine;
using System.Collections;

public class ElevatorExterior : MonoBehaviour {
	public string elevatorName = "PurgToHell";

	void OnCollisionEnter2D(Collision2D collision) {
		Application.LoadLevel("elevator"+elevatorName);
	}
}
