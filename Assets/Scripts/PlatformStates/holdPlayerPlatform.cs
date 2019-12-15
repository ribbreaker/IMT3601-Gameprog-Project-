using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdPlayerPlatform : MonoBehaviour {
    bool riding;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<canRideStuff>() != null) {
            if (other.gameObject.GetComponent<canRideStuff>().canRide) {
                if (other.transform.parent == null) {
                    other.transform.SetParent(transform);
                }
                else {
                    other.transform.parent.transform.SetParent(transform);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<canRideStuff>() != null) {
            if (other.gameObject.GetComponent<canRideStuff>().canRide)
                other.transform.SetParent(null);
        }
    }
    private void Update()
    {
        
    }
}
