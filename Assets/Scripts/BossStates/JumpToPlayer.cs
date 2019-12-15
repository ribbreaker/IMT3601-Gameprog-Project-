using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToPlayer : MonoBehaviour {
    private Rigidbody2D enemyRigidbody2D;
    [SerializeField] private float jumpForce = 150f;
    [SerializeField] private float jumpDistance = 100f;
    private float playerPos;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start() {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Send the enemy toward the pos of the player (only checks X)
   public void jumpTowards() {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        if (playerPos > transform.position.x) {
            enemyRigidbody2D.AddForce(new Vector2(jumpDistance, jumpForce)); // Jump right
            sr.flipX = true;
        } else {
            enemyRigidbody2D.AddForce(new Vector2(-jumpDistance, jumpForce));// Jump left
            sr.flipX = false;
        }
    }

}
