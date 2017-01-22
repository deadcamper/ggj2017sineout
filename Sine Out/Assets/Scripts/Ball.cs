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
