using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour {

    public float fadeInTimeLength = 1f;
    public float timeBeforeFadeOut = 3f;
    public float fadeOutTimeLength = 1f;
    public float timeBeforeNextScene = 1f;
    public string nextScene = "";

    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeCounter = 0f;

    private Image fade;

	void Start () {
        fade = GetComponent<Image>();
        isFadingIn = true;
	}

	void Update () {
        if (isFadingIn)
        {
            FadeIn();
        }
        else if (isFadingOut)
        {
            FadeOut();
        }
	}

    void FadeIn()
    {
        fadeCounter += Time.deltaTime;

        Color col = fade.color;
        col.a = Mathf.Clamp(1 - fadeCounter/fadeInTimeLength, 0, 1);
        fade.color = col;

        if (fadeCounter >= fadeInTimeLength)
        {
            fadeCounter = 0f;
            isFadingIn = false;
            Invoke("StartFadeOut", timeBeforeFadeOut);
        }
    }

    void FadeOut()
    {
        fadeCounter += Time.deltaTime;

        Color col = fade.color;
        col.a = Mathf.Clamp(fadeCounter / fadeOutTimeLength, 0, 1);
        fade.color = col;

        if (fadeCounter >= fadeOutTimeLength)
        {
            fadeCounter = 0f;
            isFadingOut = false;
            Invoke("DoNextScene", timeBeforeNextScene);
        }
    }

    void StartFadeOut()
    {
        isFadingOut = true;
    }

    void DoNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
