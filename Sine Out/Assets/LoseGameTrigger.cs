using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameTrigger : MonoBehaviour {

	public Canvas gameOverScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collision) {
		GameObject ball = collision.gameObject;
		if (ball.tag.Equals("Ball")) {
			Debug.Log("Ball found.");
			gameOverScreen.enabled = true;
		}
	}
}
