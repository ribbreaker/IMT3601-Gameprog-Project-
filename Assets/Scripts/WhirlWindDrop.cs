using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlWindDrop : MonoBehaviour {

    AreaEffector2D ae;
    float forceMag;
    float dampingDrag;
    
    // Start is called before the first frame update
    void Start() {
        ae = GetComponent<AreaEffector2D>();
        forceMag = ae.forceMagnitude;
        dampingDrag = ae.drag;
    }

    // Update is called once per frame
    void Update() {
        // If the player pushes the "down" button
        if (Input.GetAxis("Vertical") < 0) {
            // Make the whirlwind "less powerfull", effectively dropping the player slowly down
            ae.forceMagnitude = 30;
            ae.drag = 0;
        } else {
            // When the player no longer holds down, regular forces apply
            ae.forceMagnitude = forceMag;
            ae.drag = dampingDrag;
        }
    }
}