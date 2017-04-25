﻿/** 
 * EXAMPLE CODE 
http://answers.unity3d.com/questions/179311/unity-to-arduino.html
http://www.dyadica.co.uk/unity3d-serialport-script/
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System;

public class ArduinoController : MonoBehaviour {
	
	//SerialPortConnectorMac portConnect;
	private Rigidbody rb;
	public static SerialPort sp;
	public static string strIn;
	public static List<string> portList;
	public float smooth = 2.0F;
	private Vector3 prevPosition;
	void Start () {
		rb = GetComponent<Rigidbody> ();
//		Debug.Log (System.IO.Ports.SerialPort.GetPortNames ().Length);
//		foreach (string p in System.IO.Ports.SerialPort.GetPortNames()) {
//			Debug.Log (p);
//		}


		portList = GetPortNames ();
		/*
		foreach (string port in portList) {
			Debug.Log (port);
		}
		*/
		Debug.Log (portList [3]);
		// MY BACK USB PORT
		sp = new SerialPort("/dev/cu.usbmodem641", 9600, Parity.None, 8, StopBits.One);
		// MY FRONT USB PORT
		// sp = new SerialPort("/dev/cu.usbmodem411", 9600, Parity.None, 8, StopBits.One)

		//sp = new SerialPort(portList[3], 9600, Parity.None, 8, StopBits.One);

		OpenConnection();

//		portConnect = new SerialPortConnectorMac ();
//		portConnect.Open ();
//		Debug.Log("PORT: " + portConnect.Readline ());

	}

	List<string> GetPortNames ()
	{
		List<string> serialPorts = new List<string> ();
		string[] ttys = Directory.GetFiles ("/dev/", "tty.*");
		foreach (string dev in ttys) {
			// if (dev.StartsWith ("/dev/tty.*"))
				serialPorts.Add (dev);
		}

		string[] cus = Directory.GetFiles ("/dev/", "cu.*");
		foreach (string dev in cus) {
			// if (dev.StartsWith ("/dev/cu.*"))
				serialPorts.Add (dev);
		}

		return serialPorts;

	}

	//Function connecting to Arduino
	public void OpenConnection() 
	{
		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				Debug.Log( "Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 50;  // sets the timeout value before reporting error
				Debug.Log("Port Opened!");
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sp != null) {
			try{
				//Read incoming data
				strIn = sp.ReadLine ();
				if(! string.IsNullOrEmpty(strIn)){
					print(sp.ReadLine());
					// Split string into an array
						string[] arduinoData = strIn.Split(',');
					Debug.Log("Index 3: " + arduinoData.GetValue(3)+" Index 7: " + arduinoData.GetValue(7)+" Index 11: " + arduinoData.GetValue(11));
					MoveObject(arduinoData);
				}
			}
			catch(Exception ex){
				// Do nothing - just ignore	
			}
		}
	}

	void OnApplicationQuit() 
	{
		sp.Close();
	}

	void MoveObject(string[] arduinoData){
		//if (arduinoData.Length == 9) {
			Debug.Log ("called MoveObject");
			transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

			/*
			 * We need to calculate new position of the object based on acceleration.
			 * The data that comes in from the accelerometer is in meters per second per second (m/s^2)
			 * The equation is: s = ut + (1/2)a t^2
			 * where s is position, u is velocity at t=0, t is time and a is a constant acceleration.
			 * For example, if a car starts off stationary, and accelerates for two seconds with an 
			 * acceleration of 3m/s^2, it moves (1/2) * 3 * 2^2 = 6m
			 */

//
//			float accX = float.Parse(arduinoData [1]) / 100; // Accelerometer X
//			float accY = float.Parse(arduinoData [2]) / 100; // Accelerometer Y
//			float accZ = float.Parse(arduinoData [3]) / 100; // Accelerometer Z
//
//			float newAccX = transform.position.x + accX;
//			float newAccY = transform.position.y + accY;
//			float newAccZ = transform.position.z + accZ;
//
//			rb.AddForce (newAccX, newAccY, newAccZ);
//
//			transform.position = new Vector3(newAccX, newAccY, newAccZ);
//			transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);


			float gyroX = float.Parse(arduinoData[9],
				System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
			float gyroY = float.Parse (arduinoData [10],
			    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
			float gyroZ = float.Parse (arduinoData [11],
			    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
		//	this.transform.Rotate (this.transform.rotation.x + gyroX, this.transform.rotation.y + gyroY, this.transform.rotation.z + gyroZ);

		transform.rotation = Quaternion.Euler (Mathf.Clamp(transform.rotation.x + gyroX, -15.0f, 15.0f), Mathf.Clamp(transform.rotation.y + gyroY, -15.0f, 15.0f), Mathf.Clamp(transform.rotation.z + gyroZ, -15.0f, 15.0f));


//		Vector3 rot = new Vector3 (gyroX, gyroY, gyroZ);
//			Debug.Log (rot);
//			this.rb.transform.Rotate (gyroX, gyroY, gyroZ);
			//			float newGyroY = this.transform.rotation.y + gyroY;
//			float newGyroZ = this.transform.rotation.z + gyroZ;




//			transform.rotation = Quaternion.Euler(newGyroX, newGyroY, newGyroZ);
//			 Quaternion target = Quaternion.Euler(newGyroX, newGyroY, newGyroZ);
//			transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


		//}
	}


	public bool IsNumber(string s) {
		bool value = true;
		foreach(char c in s.ToCharArray()) {
			value = value && char.IsDigit(c);
		}

		return value;
	}

}
