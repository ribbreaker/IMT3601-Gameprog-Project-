using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseCollider : MonoBehaviour
{
    bool movingRight;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            movingRight = true;
        }
        
    }
    private void Update() {
        if (movingRight) {
            //are you moving left? move right.
            if (!GetComponentInParent<cartMovement>().movingRight) {
                GetComponentInParent<cartMovement>().movingRight = true;
                movingRight = false;
            }
        }
    }
}
