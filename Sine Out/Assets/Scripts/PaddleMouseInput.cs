using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMouseInput : MonoBehaviour {

    private Camera mainCamera;

    public Collider2D leftWall, rightWall;

    private float yPosition;

    private Collider2D paddleCollider;

	void Start () {
        mainCamera = Camera.main;
        paddleCollider = GetComponent<Collider2D>();

        yPosition = transform.position.y;
	}

	void Update () {

        if (Input.mousePresent)
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 paddlePos = transform.position;
            Bounds paddleBounds = paddleCollider.bounds;

            paddlePos.x = worldMousePos.x;
            paddlePos.x = Mathf.Clamp(paddlePos.x, leftWall.bounds.max.x + paddleBounds.size.x /2, rightWall.bounds.min.x - paddleBounds.size.x / 2);

            transform.position = paddlePos;
        }
    }

}
