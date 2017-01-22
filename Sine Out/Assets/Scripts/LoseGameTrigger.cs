using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGameTrigger : MonoBehaviour {

    public GameUIController gameUI;

	void Start () {
        gameUI = GameObject.FindObjectOfType<GameUIController>();
	}

	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collision) {
		GameObject ball = collision.gameObject;
		if (ball.tag.Equals("Ball")) {
            gameUI.LoseGame();
        }
	}
}
