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
		musicEv = FMODUnity.RuntimeManager.CreateInstance(music); 

		// Start music at medium speed
		changeMusic (1);
	}

	void Update () {
		
	}

	public void changeMusic(float period) {
		// Set the intensity of the music based on the wave length
		if (period < 1) {
			musicEv.getParameter("Slow Speed", out slowSpeedParam);
			slowSpeedParam.setValue (1);
			mediumSpeedParam.setValue (0);
			fastSpeedParam.setValue (0);
		}
		if (period >= 1 && period < 2) {
			musicEv.getParameter("Medium Speed", out slowSpeedParam);
			slowSpeedParam.setValue (0);
			mediumSpeedParam.setValue (1);
			fastSpeedParam.setValue (0);
		}
		if (period >= 2) {
			musicEv.getParameter("Fast Speed", out slowSpeedParam);
			slowSpeedParam.setValue (0);
			mediumSpeedParam.setValue (0);
			fastSpeedParam.setValue (1);
		}

		startMusic ();
	}

	public void startMusic() {
		FMOD.Studio.PLAYBACK_STATE play_state;
		musicEv.getPlaybackState (out play_state);
		// Start music if it is not already playing	
		if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING) {
			musicEv.start ();
		}
	}
}
