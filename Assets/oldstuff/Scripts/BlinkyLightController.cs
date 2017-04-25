using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino;

public class BlinkyLightController : MonoBehaviour {
	public Arduino arduino;

	// Use this for initialization
	void Start () {
		arduino = Arduino.global;	
		arduino.Setup (ConfigurePins);
		StartCoroutine (BlinkLoop());
	}

	IEnumerator BlinkLoop(){
		while (true) {
			arduino.digitalWrite (13, Arduino.HIGH);
			yield return new WaitForSeconds (1);
			arduino.digitalWrite (13, Arduino.HIGH);
		}
	}

	void ConfigurePins(){
		arduino.pinMode (13, PinMode.OUTPUT);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
