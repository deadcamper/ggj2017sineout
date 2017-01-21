using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {
    
    public Vector2 initialVelocity;

    public float sinePeriod = 1;
    public float sineMultiplier = 1;

    private Rigidbody2D body;

    float time = 0f;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

        body.velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    private void SinWave()
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
        SinWave();
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("...");

        Vector2 vel = body.velocity;
        vel.y = -vel.y;
        body.velocity = vel;
    }
    */
}
