using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMouseInput : MonoBehaviour {

    private Camera mainCamera;

    public Collider2D leftWall, rightWall;

    private float yPosition;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;

        yPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.mousePresent)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 paddlePos = transform.position;

            Vector3 paddleSize = transform.localScale;

            paddlePos.x = worldMousePos.x;
            paddlePos.x = Mathf.Clamp(paddlePos.x, leftWall.bounds.max.x + paddleSize.x/2, rightWall.bounds.min.x - paddleSize.x / 2);

            transform.position = paddlePos;
        }
    }

}
