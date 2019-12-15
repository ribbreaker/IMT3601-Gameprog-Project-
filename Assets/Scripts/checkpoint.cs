using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

    BoxCollider2D col;
    bool reached = false;

    // Start is called before the first frame update
    void Start() {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && reached == false) {
            // TODO: set checkpoint
            reached = true;
            collision.gameObject.GetComponent<playerController>().checkpoint = transform.position;
            Debug.Log(collision.gameObject.GetComponent<playerController>().checkpoint);
        }
    }
}