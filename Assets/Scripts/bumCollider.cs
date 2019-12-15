using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumCollider : MonoBehaviour
{
  
    bool movingLeft;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            movingLeft = true;
        }

    }
    private void Update() {
        if (movingLeft) {
            //are you moving right? move left.
            if (GetComponentInParent<cartMovement>().movingRight) {
                GetComponentInParent<cartMovement>().movingRight = false;
                movingLeft = false;
            }
        }
    }
}
