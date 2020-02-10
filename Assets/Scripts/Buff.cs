﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff {

    private GameObject bombPrefab;
    private GameObject starPrefab;
    private GameObject speedPrefab;
    private GameObject gnomePrefab;
    private GameObject prefabSelected;
    
    public Buff() {
        bombPrefab = Resources.Load("Prefabs/Bomb") as GameObject;
        starPrefab = Resources.Load("Prefabs/Star") as GameObject;
        speedPrefab = Resources.Load("Prefabs/Speed") as GameObject;
        gnomePrefab = Resources.Load("Prefabs/Gnome") as GameObject;
    }

    public void generateBuff(GameObject brick) {
        int rand = UnityEngine.Random.Range(0, 12);
        if (rand > 3) {
            prefabSelected = bombPrefab;
        } else if (rand > 7) {
            prefabSelected = starPrefab;
        } else if (rand > 10) {
            prefabSelected = gnomePrefab;
        } else {
            prefabSelected = speedPrefab;
        }
        GameObject powerUp = GameObject.Instantiate(prefabSelected, new Vector3(brick.transform.position.x, brick.transform.position.y, 0), Quaternion.identity);
    }

}
