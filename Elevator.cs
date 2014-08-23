using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

	public string destination = "hell";
	
	void Update () {
		if(!audio.isPlaying) {
			Application.LoadLevel(destination);
		}
	}
}
