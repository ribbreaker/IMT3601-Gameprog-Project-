using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSunBehaviour : MonoBehaviour {

    Rigidbody2D rb;
    private int BossHP;
    private int wheelsSpawned;

    // Start is called before the first frame update
    void Start() {
        // Deactivate the black wheel
        foreach (Transform child in transform) {
            child.GetComponent<SpriteRenderer>().enabled = false;
            child.GetComponent<CircleCollider2D>().enabled = false;
        }

        // Send the boss in a direction. The rigid body with material and circle collider will sort out the bouncing
        rb = GetComponentInParent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);

        BossHP = GetComponent<EnemyController>().HP;
        wheelsSpawned = 0;
    }

    private void Update() {
        // If the boss lost health, activate one of the wheels
        if (BossHP > GetComponent<EnemyController>().HP) {
            // Activate the next wheel
            transform.GetChild(wheelsSpawned).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(wheelsSpawned).GetComponent<CircleCollider2D>().enabled = true;


            //Update HP and number of wheels spawned
            BossHP = GetComponent<EnemyController>().HP;
            wheelsSpawned++;
        }
    }
}
