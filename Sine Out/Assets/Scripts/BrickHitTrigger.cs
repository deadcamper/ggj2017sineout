using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHitTrigger : MonoBehaviour {

	public float sinePeriod = 1;
	public float sineMultiplier = 1;
	public bool ignoreWaveChange = true;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		gameObject.SetActive(false);
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null) {
			if (!ignoreWaveChange) {
				ball.turnSineWaveOn ();
				ball.setWaveLength (sinePeriod, sineMultiplier);
			}
		}
	}
}
