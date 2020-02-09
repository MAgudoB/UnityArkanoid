using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff{

    private GameObject bombPrefab;
    private GameObject starPrefab;
    private GameObject prefabSelected;

    public Buff() {
        bombPrefab = Resources.Load("Prefabs/Bomb") as GameObject;
        starPrefab = Resources.Load("Prefabs/Star") as GameObject;        
    }

    public void generateBuff(GameObject brick) {

        if (UnityEngine.Random.Range(0, 10) > 5) {
            prefabSelected = bombPrefab;
        } else {
            prefabSelected = starPrefab;
        }
        GameObject powerUp = GameObject.Instantiate(prefabSelected, new Vector3(brick.transform.position.x, brick.transform.position.y, 0), Quaternion.identity);
    }

}
