using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomePowerUp : Powers {
    private void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);
        GameObject player = collision.gameObject;
        if (player.tag == "Player" &&
        (!player.GetComponent<PlayerController>().buffed || !player.GetComponent<PlayerController>().speedBuffed)) {
            player.transform.localScale = new Vector3(player.transform.localScale.x * 0.5f, player.transform.localScale.y * 0.5f, player.transform.localScale.z);
            player.GetComponent<PlayerController>().buffed = true;
            Destroy(this.gameObject);
        }
    }
}
