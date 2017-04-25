using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > .2) {
			foreach (Transform child in transform) {
				transform.RotateAround (Vector3.zero, Vector3.back, 0.1f);
			}
		}
		if (Input.GetAxis ("Horizontal") < -.2) {
			foreach (Transform child in transform) {
				transform.RotateAround (Vector3.zero, Vector3.forward, 0.1f);
			}
		}
		if (Input.GetAxis ("Vertical") > .2) {
			foreach (Transform child in transform) {
				transform.RotateAround (Vector3.zero, Vector3.right, 0.1f);
			}
		}
		if (Input.GetAxis ("Vertical") < -.2) {
			foreach (Transform child in transform) {
				transform.RotateAround (Vector3.zero, Vector3.left, 0.1f);
			}
		}
	}
}
