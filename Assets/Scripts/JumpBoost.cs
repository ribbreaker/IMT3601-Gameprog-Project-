using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField] enum COLOR { RED, BLUE };

public class JumpBoost : MonoBehaviour
{

    public float pushForce;
    void OnTriggerEnter2D(Collider2D other){
        bounceEntity(other.transform);
    }
    void bounceEntity(Transform pushedObject){
        Vector2 pushDirection = new Vector2(0,(pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushForce;
        if (pushedObject.gameObject.GetComponent<Rigidbody2D>() != null) {
            Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
            pushRB.velocity = Vector2.zero;
            pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
        }
    }
}
