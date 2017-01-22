using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	
	[FMODUnity.EventRef]
	public string music = "event:/Music/Level 1";
	FMOD.Studio.EventInstance musicEv;
	FMOD.Studio.ParameterInstance slowSpeedParam;
	FMOD.Studio.ParameterInstance mediumSpeedParam;
	FMOD.Studio.ParameterInstance fastSpeedParam;

	void Start () {
		
		// Start music if it is not already playing	
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music); 
		musicEv.getParameter("Slow Speed", out slowSpeedParam);
		FMOD.Studio.PLAYBACK_STATE play_state;
		musicEv.getPlaybackState (out play_state);
		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING) {
			startMusic ();
		}
	}

	void Update () {
		
	}

	public void startMusic() {
		slowSpeedParam.setValue (1);
		musicEv.start ();
	}

	public void changeMusic(float period) {
		// Set the intensity of the music based on the wave length
		if (period < 1) {
			slowSpeedParam.setValue (1);
			mediumSpeedParam.setValue (0);
			fastSpeedParam.setValue (0);
		}
		if (period > 1 && period < 2) {
			slowSpeedParam.setValue (0);
			mediumSpeedParam.setValue (1);
			fastSpeedParam.setValue (0);
		}
		if (period >= 2) {
			slowSpeedParam.setValue (0);
			mediumSpeedParam.setValue (0);
			fastSpeedParam.setValue (1);
		}
	}
}
