using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	//public float commonZ;
	//public GameObject border;
	public GameObject marble;
	public GameObject floor;
	private int ballcount = 0;

	// Use this for initialization
	void Start () {
		//border = Resources.Load ("Prefabs/OutsideWalls") as GameObject;
	GameObject newFloor = (GameObject)Instantiate (floor);
		GameObject newMarble = (GameObject)Instantiate (marble);
//		GameObject newBorder = (GameObject)Instantiate (border);
//		newBorder.transform.parent.SetParent (newFloor.transform);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space") && ballcount == 0) {
			GameObject newMarble = (GameObject)Instantiate (marble);
			ballcount++;
		}
			
	}
}
