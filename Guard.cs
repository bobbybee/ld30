using UnityEngine;
using System.Collections;

public class Guard : MonoBehaviour {

	public Rect keyLocation;
	public AudioSource taunt;
	public AudioSource master;

	public int grabKeyTime = 0;

	public Sprite portalSprite;

	private bool keyGrabbed = false;
	private bool isPortal = false;

	void Update () {
		if(keyGrabbed && !master.isPlaying) {
			keyGrabbed = false;
			isPortal = true;

			transform.localScale = new Vector3(2,2,1);

			(renderer as SpriteRenderer).sprite = portalSprite;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(!keyGrabbed && !isPortal) {
			taunt.Play();
			grabKeyTime = 90;
		} else if(isPortal) {
			Application.LoadLevel("control room");
		}
	}

	void OnGUI() {
		if(grabKeyTime > 0) {
			grabKeyTime--;

			if(GUI.Button(keyLocation, "Grab key")) {
				taunt.Stop();

				keyGrabbed = true;

				master.Play();
			}
		}
	}
}
