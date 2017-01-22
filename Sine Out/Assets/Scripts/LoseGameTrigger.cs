using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameTrigger : MonoBehaviour {

	public Canvas gameOverScreen;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collision) {
		GameObject ball = collision.gameObject;
		if (ball.tag.Equals("Ball")) {
			gameOverScreen.enabled = true;
		}
	}
}
