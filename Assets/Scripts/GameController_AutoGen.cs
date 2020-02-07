using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_AutoGen : MonoBehaviour {
    // Start is called before the first frame update
    public int sceneLevel = 1;
    public int nLives = 3;
    private int wallRows = 1;
    private int uRange = 0;
    private int overAllScore = 0;
    private int levelScore = 0;
    private float brickWidth;
    private float brickHeigth;
    private float screenOffset;
    private float cameraWidth;
    private bool gameStarted;
    private GameObject easyBrickPrefab;
    private GameObject mediumBrickPrefab;
    private GameObject hardBrickPrefab;
    private GameObject unbreakableBrickPrefab;
    private GameObject selectedBrick;
    private GameObject brickWall;
    private GameObject playerPrefab;
    private GameObject ballPrefab;
    private GameObject playerPaddle;


    void Awake() {
        //Prefabs initiation
        brickWall = GameObject.FindGameObjectWithTag("BrickWall");
        playerPaddle = GameObject.FindGameObjectWithTag("Player");
        easyBrickPrefab = Resources.Load("Prefabs/EasyBrick") as GameObject;
        mediumBrickPrefab = Resources.Load("Prefabs/MediumBrick") as GameObject;
        hardBrickPrefab = Resources.Load("Prefabs/HardBrick") as GameObject;
        unbreakableBrickPrefab = Resources.Load("Prefabs/UnbreakableBrick") as GameObject;
        playerPrefab = Resources.Load("Prefabs/PlayerPaddle") as GameObject;
        ballPrefab = Resources.Load("Prefabs/Ball") as GameObject;
        screenOffset = 1;
        brickWidth = 0.6f;
        brickHeigth = 0.3f;
        cameraWidth = (2f * Camera.main.orthographicSize) * Camera.main.aspect;
        SetLevel();
        SetBrickWall();

    }

    /**
     * SetLevel
     * Set level variables as how many rows the wall will have and how common unbreakable bricks are.
     **/
    private void SetLevel() {
        switch (sceneLevel) {
            case 1:
                wallRows = 1;
                uRange = 11;
                break;
            case 2:
                wallRows = 2;
                uRange = 9;
                break;
            case 3:
                wallRows = 4;
                uRange = 7;
                break;
            default:
                break;
        }
    }

    /**
     * SetBrickWall
     * No parameters
     * Random generation of the wall of bricks
     **/
    private void SetBrickWall() {
        for (int i = 0; i < wallRows; i++) {
            for (float x = screenOffset; x < cameraWidth-screenOffset; x++) {
                selectedBrick = unbreakableBrickPrefab;
                if (UnityEngine.Random.Range(1, 10) < uRange) {
                    switch (UnityEngine.Random.Range(1, 3)) {
                        case 1:
                            selectedBrick = easyBrickPrefab;
                            break;
                        case 2:
                            selectedBrick = mediumBrickPrefab;
                            break;
                        case 3:
                            selectedBrick = hardBrickPrefab;
                            break;
                        default:
                            selectedBrick = easyBrickPrefab;
                            break;
                    }
                }
                GameObject brick = GameObject.Instantiate(selectedBrick, new Vector3(x * brickWidth, i * brickHeigth, 0), Quaternion.identity, brickWall.transform);
            }
        }
    }



    // Update is called once per frame
    void Update() {
        if (!gameStarted) {
            if (Input.GetAxis("Jump") > 0) {
                //Shoot ball 1st time
            }
        }
        //calculate player movement
        //calculate ball movement
        //calculate ball collission
        //calculate bonus drop if any
    }
}
