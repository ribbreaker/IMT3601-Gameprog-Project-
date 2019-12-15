using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformWhenPlayerTouches : MonoBehaviour {
    public float speed;
    private Vector3 pos1, pos2;
    private bool playerOn = false;

    void Start() {
        pos1 = transform.GetChild(0).position;
        pos2 = transform.GetChild(1).position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.collider.transform.SetParent(transform);
        playerOn = true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.collider.transform.SetParent(null);
        playerOn = false;
    }

    private void Update() {
        if (playerOn)
            transform.position = Vector2.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        else {
            if (transform.position != pos1)
                transform.position = Vector2.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
        }
    }
}
