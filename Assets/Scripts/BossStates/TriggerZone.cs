using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {
    public JumpToPlayer parent;
    [SerializeField] float jumpCoolDown;
    float countDown;
    bool jumping;
    public bool attack;

    // Start is called before the first frame update
    void Start() {
        parent = transform.parent.GetComponentInParent<JumpToPlayer>();
        countDown = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {    // Player is within the boss' aggro-range
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {    // Player left the aggro-range
            attack = false;
        }
    }
    
    void Update() {
        if (attack) {   // Is the player here?
            if (countDown == 0) {   // Can i jump?
                parent.jumpTowards();    // Start jumping
                countDown = jumpCoolDown;// I just jumped
            }
                    // To stop the countdown from counting bellow 0
            if (countDown > 0) {
                countDown -= Time.deltaTime;
            } else if (countDown <= 0) {
                countDown = 0;
            }
        }
    }
}
