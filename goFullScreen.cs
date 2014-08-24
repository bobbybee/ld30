using UnityEngine;
using System.Collections;

public class goFullScreen : MonoBehaviour {
	void Start() {
		if(Application.isWebPlayer) {
			Screen.fullScreen = true;
		}
	}
}
