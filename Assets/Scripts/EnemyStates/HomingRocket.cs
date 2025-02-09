﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour {
    private GameObject target;
    private Rigidbody2D projectile;
    public GameObject poof;
    Vector2 dir;
    [SerializeField] private float speed = 5f, rotateSpeed = 200f;
    private float rotateAmount;
    [SerializeField]private float aliveTime;
    private float time;
    private EnemyController controller;


    // Start is called before the first frame update
    void Start() {
        controller = GetComponent<EnemyController>();
        projectile = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        if (aliveTime == 0)
            aliveTime = 5;
    }


    // Update is called once per frame
    void FixedUpdate() {
            time += Time.deltaTime;
            if (time >= aliveTime) {                                          // Destroy the projectile if it has been alive for more than 5 seconds
                controller.takeDamage(1);
            }
            if (target != null) {
                dir = (Vector2)target.transform.position - projectile.position;           // Set the direction
                dir.Normalize();
            }
            rotateAmount = Vector3.Cross(dir, -transform.right).z;          // -transform.right for transform.left

            projectile.angularVelocity = -rotateAmount * rotateSpeed;       // Minus to move towards the goal, plus to move away
            projectile.velocity = -transform.right * speed;


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            controller.takeDamage(1);
        }
    }
}
