using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    //Variable declaration
    public float ballSpeed = 10f;
    public float bounceSpeed = 1.0f;
    public float bounceAmount = 2.0f;
    private Vector2 currentSpeed;
    private Rigidbody2D rigidBody;
    private Collider2D collider;
    private GameObject playerPaddler;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentSpeed = rigidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;
        Vector2 speedVector = new Vector2(Mathf.Clamp(currentSpeed.x,-ballSpeed,ballSpeed), Mathf.Clamp(currentSpeed.y, -ballSpeed, ballSpeed));
        rigidBody.AddForce(Vector3.Reflect(speedVector, collision.contacts[0].normal) * rigidBody.mass, ForceMode2D.Impulse);
    }
}
