using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTon : MonoBehaviour
{
    public bool Pressed;

    void OnTriggerEnter2D(Collider2D other) {
        if(!Pressed)
            Pressed = true;
    }

    private void Update() {
        if (Pressed) {
            RecursivePress();
        }
        
    }
    private void RecursivePress() {
        foreach (Transform i in transform) {
            //if there's another button
            if(i.GetComponent<BUTTon>() != false) {
                //go through it's children as well
                i.GetComponent<BUTTon>().RecursivePress();
            } 

            Debug.Log("Pressed");
            //Does it have a doorcollapse script?
            if (i.GetComponent<doorCollapse>() != false) {
                Debug.Log("Has doorCollapse script");
                //Destroy it.
                i.GetComponent<doorCollapse>().explodeMe();
            }
            
        
        }
        
    }
}
