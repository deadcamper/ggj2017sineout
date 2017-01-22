using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	
	[FMODUnity.EventRef]
	public string music = "event:/Music/Level 1";

	FMOD.Studio.EventInstance musicEv;                  //cube event music
	FMOD.Studio.ParameterInstance musicEndParam;        //end param object (for to the end of music)

	// Use this for initialization
	void Start () {
		// Start music if it is not already playing
		FMOD.Studio.PLAYBACK_STATE play_state;
		musicEv.getPlaybackState (out play_state);
		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING) {
			musicEv.start ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeMusic(float period) {
		// Set the intensity of the music based on the wave length
		if (period < 1) musicEndParam.setValue (0);
		if (period > 1 && period < 2) musicEndParam.setValue (1);
		if (period >= 2) musicEndParam.setValue (2);
	}
}
