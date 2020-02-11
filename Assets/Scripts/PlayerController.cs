using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Script to define user's movement
 **/

public class PlayerController : MonoBehaviour {
    //Variable declaration
    public float playerLifes = 3;
    public float playerSpeed = 5f;
    public int score = 0;
    public float horizontalInput;
    public bool buffed = false;
    public bool speedBuffed = false;
    private float timeBuffed;
    private Vector2 movement;
    private Rigidbody2D rigidBody;
    private GameObject ball;
    private GameObject brickWall;
    private Canvas canvas;
    private bool gameStarted;

    private void Start() {
        gameStarted = false;
        rigidBody = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        brickWall = GameObject.FindGameObjectWithTag("BrickWall");
        DontDestroyOnLoad(ball);
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnLevelWasLoaded(int level) {
        ball = GameObject.FindGameObjectWithTag("Ball");
        brickWall = GameObject.FindGameObjectWithTag("BrickWall");
    }

    // During update we will check user's inputs.
    void FixedUpdate() {
        GameObject nLives = GameObject.FindGameObjectWithTag("GameController");
        nLives.GetComponent<Text>().text = playerLifes.ToString();
        //If game hasn't started we can push the ball
        if (!gameStarted) {
            horizontalInput = Input.GetAxis("Horizontal");
            movement = new Vector2(horizontalInput * playerSpeed, 0);
            rigidBody.velocity = movement;
            ball.GetComponent<Rigidbody2D>().velocity = movement;
            if (Input.GetAxis("Jump") > 0) {
                gameStarted = true;
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 3), ForceMode2D.Impulse);
            }
        } else {
            horizontalInput = Input.GetAxis("Horizontal");
            rigidBody.velocity = new Vector2(horizontalInput * playerSpeed, 0);
            //If brickWall has no child left, we can load the next level
            if (brickWall.gameObject.transform.childCount == 0) {
                this.gameObject.transform.position = new Vector3(0, -4.08f, 0);
                ball.transform.position = new Vector3(0, -3.68f, 0);
                gameStarted = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            //If we are buffed in any way, we count up to 10 and then revert the changes
            if (buffed || speedBuffed) {
                timeBuffed += Time.deltaTime;
                if (timeBuffed > 10) {
                    if (speedBuffed) {
                        playerSpeed = 5f;
                        timeBuffed = 0;
                        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(255, 255, 255);
                        speedBuffed = false;
                    } else {
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        timeBuffed = 0;
                        buffed = false;
                    }
                }
            }
            //If playerLifes becomes 0 or less we reset the game.
            if (playerLifes <= 0) {
                SceneManager.LoadScene("Level1");
                Destroy(ball);
                Destroy(this.gameObject);
            }
        }
    }
}