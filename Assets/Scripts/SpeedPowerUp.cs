using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : Powers {
    private void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerController>().playerSpeed += 5f;
            collision.gameObject.GetComponent<PlayerController>().speedBuffed = true;
            collision.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0,255,0);
            Destroy(this.gameObject);
        }
    }
}
