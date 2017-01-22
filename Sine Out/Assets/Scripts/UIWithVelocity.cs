using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIWithVelocity : MonoBehaviour {

    public Vector2 velocity;

    RectTransform rect;

	// Use this for initialization
	void Start () {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 position = rect.position;

        position = position + (Vector3)(velocity) * Time.fixedDeltaTime * 10;

		if (rect.position.x < -15f) {
			position.x = 15f;
			rect.position = position;
		} else {
			rect.position = position; 
		} 
	}
}
