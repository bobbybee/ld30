﻿using UnityEngine;
using System.Collections;

public class OpenCharacter : MonoBehaviour {

	public float movementSpeed = 0.1f;

	void Start () {
	
	}
	
	void Update () {
		Vector2 movementVector = new Vector2(Input.GetAxis("Horizontal"), 0);

		if(movementVector.magnitude > 0.2) {
			transform.position = (Vector2) transform.position + (movementVector * movementSpeed);
		}
	}

}
