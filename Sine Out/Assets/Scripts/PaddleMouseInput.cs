using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMouseInput : MonoBehaviour {

    public GameObject dummyBall;
    public Ball launchBallPrefab;
    public Collider2D leftWall, rightWall;

    private Vector2 paddleVelocity;

    private float yPosition;

    private Camera mainCamera;

    private Collider2D paddleCollider;

    private bool isPrelaunch = true;

	void Start () {
        mainCamera = Camera.main;
        paddleCollider = GetComponent<Collider2D>();

        yPosition = transform.position.y;
	}

	void Update () {

        if (Input.mousePresent)
        {
            // Move the paddle
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector3 paddlePos = transform.position;
            Bounds paddleBounds = paddleCollider.bounds;

            Vector3 lastPaddlePos = paddlePos;

            paddlePos.x = worldMousePos.x;
            paddlePos.x = Mathf.Clamp(paddlePos.x, leftWall.bounds.max.x + paddleBounds.size.x /2, rightWall.bounds.min.x - paddleBounds.size.x / 2);

            transform.position = paddlePos;

            paddleVelocity = new Vector2(paddlePos.x - lastPaddlePos.x, 0) / Time.deltaTime;

            // Launch ball
            if (isPrelaunch && Input.GetMouseButtonDown(0))
            {
                LaunchBall();
            }

        }
    }

    private void LaunchBall()
    {
        isPrelaunch = false;
        Ball ball = GameObject.Instantiate<Ball>(launchBallPrefab, dummyBall.transform.position, Quaternion.identity);
        dummyBall.SetActive(false);
    }

    private void SpinBall(Ball ball, Vector2 addVelocity)
    {
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        Vector2 ballVelocity = rb.velocity;

        rb.velocity = ballVelocity + addVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Ball ball = collision.gameObject.GetComponent<Ball>();

            Vector2 position = collision.contacts[1].point;

            Vector3 offset = (Vector3)position - transform.position;

            offset.y = 0;

            SpinBall(ball, offset);
        }
    }

}
