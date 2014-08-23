using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public float movementSpeed = 0.2f;

	void Start () {
	
	}
	
	void Update () {
		Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		if(movementVector.magnitude > 0.2) {
			transform.position = (Vector2) transform.position + (movementVector * movementSpeed);
		}
	}

}
