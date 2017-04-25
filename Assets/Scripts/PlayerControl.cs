using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
//	public float speed;		// we set this to 2
//	public Vector3 move;
	public Rigidbody pacman;
	public int score;
	public Text scoreDisplay;
//	public int lives;
//	public Text livesDisplay;
//	public Text winText;
//	public Text endGame;

	// Use this for initialization
	void Start () {
		pacman = GetComponent<Rigidbody> ();
		score = 0;
		scoreDisplay.text = "Levels Completed: " + score;
//		lives = 3;
//		livesDisplay.text = "Lives: " + lives;
//		endGame.text = "";
//		winText.text = "";
	}

	// Update is called once per frame
	// waits until everything in the scene is done rendering before the code executes
//	void FixedUpdate () {
//		// the longer you hold a key down (or how hard you press it) means more force is applied
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		move = new Vector3 (Mathf.Clamp(moveHorizontal,-9.5f, 9.5f), 0.0f, Mathf.Clamp(moveVertical,-9.5f, 9.5f));
//
//		pacman.AddForce (move * speed);
//	}

	// this is an event listener
	// all event listeners are void
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Goal")) {
			score++;
			scoreDisplay.text = "Levels Completed: " + score;
//			if (score == CoinGenerator.numCoins) {
//				winText.text = "You win!";
//				GameObject[] gos = GameObject.FindGameObjectsWithTag("Ghosts");
//				foreach (GameObject g in gos) {
//					g.SetActive (false);
//				}
//
//			}
		}
//		if (other.gameObject.CompareTag ("Ghosts")) {
//			if (lives > 0) {
//				lives -= 1;
//			} else {
//				lives = 0;
//			}
//			livesDisplay.text = "Lives: " + lives;
//			if (lives == 0) {
//				endGame.text = "Game Over!";
//				GameObject[] cos = GameObject.FindGameObjectsWithTag("Coins");
//				foreach (GameObject c in cos) {
//					c.SetActive (false);
//				}
//			}
//		}
	}
}
