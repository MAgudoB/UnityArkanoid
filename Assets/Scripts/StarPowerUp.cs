using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerUp : Powers {

    private void OnCollisionEnter2D(Collision2D collision) {
        base.OnCollisionEnter2D(collision);
        GameObject player = collision.gameObject;
        if (player.tag == "Player" &&
            (!player.GetComponent<PlayerController>().buffed || !player.GetComponent<PlayerController>().speedBuffed)) {
            player.transform.localScale = new Vector3(player.transform.localScale.x * 2, player.transform.localScale.y * 2, player.transform.localScale.z);
            player.GetComponent<PlayerController>().buffed = true;
            Destroy(this.gameObject);
        }
    }
}
