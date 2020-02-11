using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int brickLife = -1;
    
    // Update is called once per frame
    void Update() {
        if (brickLife == 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score++;
            //If bricks gets destroyed there is a small chance that it generates a powerUp
            int rand = Random.Range(0, 10);
            if (rand > 8) {
                Buff newBuff = new Buff();
                newBuff.generateBuff(this.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //Get tag of collision gameObject
        string tag = collision.gameObject.tag;
        //If its the ball, we take one point of damage
        if(tag == "Ball") {
            brickLife--;
        }
        //If its a powerUp we ignore the collision
        if(tag == "Star" || tag == "Bomb") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

}
