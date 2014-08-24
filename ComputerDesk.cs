using UnityEngine;
using System.Collections;

public class ComputerDesk : MonoBehaviour {

	public string destination = "cmd";

	void OnCollisionEnter2D(Collision2D collision) {
		Application.LoadLevel(destination);
	}
}
