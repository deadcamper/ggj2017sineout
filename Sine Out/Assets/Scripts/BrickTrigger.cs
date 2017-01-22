using FMODUnity;
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
	private MusicPlayer musicPlayer;

	void Start () {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer> ();
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
				musicPlayer.changeMusic (sineMultiplier);
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

        //Check if other bricks still exist.
        BrickTrigger trig = transform.parent.gameObject.GetComponentInChildren<BrickTrigger>();

        //If not, you win!
        if (trig == null)
        {
            GameObject.FindObjectOfType<GameUIController>().WinGame();
        }
	}
}
