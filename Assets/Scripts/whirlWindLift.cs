using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whirlWindLift : MonoBehaviour
{
    public float pushForce;
    [SerializeField] private Transform liftPoint;
    void OnTriggerStay2D(Collider2D other) {
        Debug.Log("In contact with whirlwind");
        if (other.gameObject.CompareTag("Player")) {
            other.transform.position = Vector3.MoveTowards(other.transform.position,liftPoint.transform.position, pushForce);
            //other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + pushForce, other.transform.position.z);
        }



    }
}
