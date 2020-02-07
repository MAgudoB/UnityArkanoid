using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /**
     * Script to define user's movement
     **/

public class PlayerController : MonoBehaviour {
    //Variable declaration
    public float playerSpeed = 5f;
    public float horizontalInput;
    private Vector2 movement;
    private Rigidbody2D rigidBody;

    private void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // During update we will check user's inputs.
    void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontalInput*playerSpeed, 0);
    }
}