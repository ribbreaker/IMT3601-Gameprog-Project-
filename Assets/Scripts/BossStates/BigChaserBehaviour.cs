using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigChaserBehaviour : MonoBehaviour {

    [SerializeField] private float rotationSpeed;
    [SerializeField] private float radius;
    private float angle;
    private Vector2 centre;
    private bool clockwise = true;
    private int BossHP;


    // Start is called before the first frame update
    void Start() {
        centre = transform.position;
        BossHP = GetComponent<EnemyController>().HP;
    }

    // Update is called once per frame
    void Update() {
        // If the player hit him, switch direction
        if (clockwise) {
            // Move the boss in a circular fashion!
            /// The angle of which he will move on the circle, and the direction
            angle += rotationSpeed * Time.deltaTime;    
        } else {
            angle += -rotationSpeed * Time.deltaTime;
        }
        
        /// Put him away from the centre
        var offset = new Vector2(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius);
        /// Move him
        transform.position = centre + offset;


        // To check whether he shall turn direction (If he was hit)
        if (BossHP > GetComponent<EnemyController>().HP) {
            // Turn direction 
            clockwise ^= true;

            // Store new HP
            BossHP = GetComponent<EnemyController>().HP;
            rotationSpeed += 0.5f;
        }
    }
}
