using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    [SerializeField] float speed;
    [SerializeField] float rotationRadius;
    private Vector2 center;
    private float Xpos;
    private float Ypos;
    private float angle;

    private void Start() {
        center = transform.position;
        angle = 0f;
    }

    private void Update() {
        Xpos = center.x + Mathf.Cos(angle) * rotationRadius / 2; // For oval movement
        Ypos = center.y + Mathf.Sin(angle) * rotationRadius;
        // Move
        transform.position = new Vector2(Xpos, Ypos);
        // Calculate new angle
        angle = angle + Time.deltaTime * speed;

        if (angle >= 360f) {
            angle = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collision.collider.transform.SetParent(null);
    }
}