using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    public int brickLife = -1;


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(brickLife == 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score++;
            int rand = Random.Range(0, 10);
            if (rand > 8) {
                Buff newBuff = new Buff();
                newBuff.generateBuff(this.gameObject);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string tag = collision.gameObject.tag;
        if(tag == "Ball") {
            brickLife--;
        }
        if(tag == "Star" || tag == "Bomb") {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }

}
