using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipEnemy : MonoBehaviour {
    Transform player;
    TriggerZoneAxe triggerZone;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;      // Get the Playerobject
        triggerZone = transform.GetComponentInParent<TriggerZoneAxe>();   // Get access to the TriggerZoneAxe script in child
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (player.position.x > transform.position.x && triggerZone.canFlip) {  // If the Player is to the left of me, flip to face right
            transform.rotation = Quaternion.Euler(0, -180, 0);
            triggerZone.canFlip = false;
        }
        if (player.position.x < transform.position.x && triggerZone.canFlip) {  // If the player is to the right of me, flip to face left
            transform.rotation = Quaternion.Euler(0, 0, 0);
            triggerZone.canFlip = false;
        }
    }
}
