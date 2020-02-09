using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Powers : MonoBehaviour {
    protected void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "GameOver") {
            Destroy(this.gameObject);
        }
    }
}
