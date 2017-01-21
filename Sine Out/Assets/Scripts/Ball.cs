using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour {

    public float initialSpeed;

    public Vector2 initialVelocity;

    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();

        body.velocity = initialVelocity;
	}
	
	// Update is called once per frame
	void Update () {
		
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
