using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    //Variable declaration
    public float ballSpeed = 5f;
    public float bounceSpeed = 1.0f;
    public float bounceAmount = 2.0f;
    private Vector2 currentSpeed;
    private Rigidbody2D rigidBody;
    private GameObject playerPaddler;
    private AudioSource ballHit;
    private AudioSource brickHit;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        playerPaddler = GameObject.FindGameObjectWithTag("Player");
        ballHit = playerPaddler.GetComponent<AudioSource>();
        brickHit = GameObject.FindGameObjectWithTag("Brick").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentSpeed = rigidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;
        //If I hit the GameOver area, player lifes gets reduced
        if (tag == "GameOver") {
            playerPaddler.GetComponent<PlayerController>().playerLifes--;
        }
        if (tag == "Player") {
            ballHit.Play();
        }
        if (tag == "Brick") {
            brickHit.Play();
        }
        //Now we have to apply force to the ball.
        //First, we should apply some friction so the forces don't just add up.
        //For this, we apply a force equals to the current speed plus max speed
        //rigidBody.AddForce(currentSpeed * ballSpeed);
        //Then we try to create an impulse based on its max speed.
        Vector2 friction = calculateFriction(currentSpeed);
        rigidBody.AddForce(friction);
        Vector2 speedVector = new Vector2(Mathf.Clamp(currentSpeed.x, -ballSpeed, ballSpeed), Mathf.Clamp(currentSpeed.y, -ballSpeed, ballSpeed));
        rigidBody.AddForce(Vector3.Reflect(speedVector, collision.contacts[0].normal).normalized * rigidBody.mass * ballSpeed, ForceMode2D.Impulse);
    }

    private Vector2 calculateFriction(Vector2 currentDirection) {
        float dirX = -currentDirection.x;
        float dirY = -currentDirection.y;

        return new Vector2(dirX, dirY) * ballSpeed;

    }
}
