using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMouseInput : MonoBehaviour {

    private Camera mainCamera;

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

            paddlePos.x = worldMousePos.x;
            transform.position = paddlePos;
        }
    }
}
