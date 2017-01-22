using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    
    public Vector2 initialVelocity;

    public float sinePeriod = 1;
    public float sineMultiplier = 1;
	[FMODUnity.EventRef]
	public string bounceSound = "event:/Sounds/bounce";
	[FMODUnity.EventRef]
	public string music = "event:/Music/Level 1";
	FMOD.Studio.EventInstance musicEv;                  //cube event music
	FMOD.Studio.ParameterInstance musicEndParam;        //end param object (for to the end of music)

    private Rigidbody2D body;
	private bool sineWaveTurnedOn = false;

    float time = 0f;

	void Start () {
        body = GetComponent<Rigidbody2D>();

        body.velocity = initialVelocity;
	}

	void Update () {
        
    }

    private void SineWave()
    {
        Vector3 currentMotion = body.velocity;

        Vector3 vector = Quaternion.Euler(0, 0, 90) * currentMotion;

        float lastTime = time;
        time = time + Time.fixedDeltaTime;

        float lastSin = Mathf.Sin(lastTime * sinePeriod) * sineMultiplier;
        float currentSin = Mathf.Sin(time * sinePeriod) * sineMultiplier;

        Vector3 prevPos = transform.position;
        transform.position = prevPos + (vector) * (currentSin - lastSin);
    }


    void FixedUpdate()
    {
		if (sineWaveTurnedOn) SineWave();
    }

	public void setWaveLength(float period,float multiplier) {

		// Start music if it is not already playing
//		FMOD.Studio.PLAYBACK_STATE play_state;
//		musicEv.getPlaybackState (out play_state);
//		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING) {
//			musicEv.start ();
//		}
//
////		// Set the intensity of the music based on the wave length
////		if (period < 1) musicEndParam.setValue (0);
////		if (period > 1 && period < 2) musicEndParam.setValue (1);
////		if (period >= 2) musicEndParam.setValue (2);

		this.sinePeriod = period;
		this.sineMultiplier = multiplier;
	}

	public void turnSineWaveOn() {
		sineWaveTurnedOn = true;
	}

    
    void OnCollisionEnter2D(Collision2D collision)
    {
		FMODUnity.RuntimeManager.PlayOneShot (bounceSound);
    }
}
