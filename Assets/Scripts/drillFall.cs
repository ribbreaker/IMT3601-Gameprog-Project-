using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drillFall : MonoBehaviour
{
    Transform target;
    bool activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }  
    void OnTriggerEnter2D(Collider2D other) {
        activate = true;
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player")) {
            target = other.transform;
        }
    }

    public bool GetActive() {
        return activate;
    }
    public Transform getTarget() {
        return target;
    }
}
