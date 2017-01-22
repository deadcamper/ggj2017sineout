﻿using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickTrigger : MonoBehaviour {

	public float sinePeriod = 1;
	public float sineMultiplier = 1;
	public bool ignoreWaveChange = true;
	[FMODUnity.EventRef]
	public string breakSound = "event:/Sounds/break";

	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		gameObject.SetActive(false);
		Ball ball = collision.gameObject.GetComponent<Ball>();
		if (ball != null) {

            if (!ignoreWaveChange)
            {

                // Turn wave on
                ball.turnSineWaveOn();
                ball.setWaveLength(sinePeriod, sineMultiplier);
            }

            // Play break sound
            try
            {
                FMODUnity.RuntimeManager.PlayOneShot(breakSound);
            }
            catch (Exception enfe)
            {
                Debug.LogWarning("Bad sound :" + breakSound);
            }
            

		}
	}
}