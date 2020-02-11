using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : Powers {
    private void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player") {
            //bomb rest one to players total life
            collision.gameObject.GetComponent<PlayerController>().playerLifes--;
            Destroy(this.gameObject);
        }
    }
}
