using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{


    public float aliveTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, aliveTime);
    }
    //If it touches an enemy or a wall, destroy it
    void OnTriggerEnter2D(Collider2D other) {
        var animator = GetComponentInChildren<Animator>();
        if (other.gameObject.CompareTag("Enemy")){
            animator.SetBool("dead", true);
        }
    }

}
