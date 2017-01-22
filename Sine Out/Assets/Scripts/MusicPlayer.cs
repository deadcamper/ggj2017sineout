using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	
	[FMODUnity.EventRef]
	public string music = "event:/Music/Level 1";
	FMOD.Studio.EventInstance musicEv;                  //cube event music
	FMOD.Studio.ParameterInstance musicEndParam;        //end param object (for to the end of music)

	void Start () {
		
		// Start music if it is not already playing
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music); 
		FMOD.Studio.PLAYBACK_STATE play_state;
		musicEv.getPlaybackState (out play_state);
		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING) {
			startMusic ();
		}
	}

	void Update () {
		
	}

	public void startMusic() {
		musicEv.start ();
	}

	public void changeMusic(float period) {
		// Set the intensity of the music based on the wave length
//		if (period < 1) musicEndParam.setValue (0);
//		if (period > 1 && period < 2) musicEndParam.setValue (1);
//		if (period >= 2) musicEndParam.setValue (2);
	}
}
