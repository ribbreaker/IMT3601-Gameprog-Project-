using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScroll : MonoBehaviour
{
    public playerController player;
    //Where the camera will start autoscrolling
    public float triggerPosition;
    public float scrollSpeed;
    bool scrolling;

    

    // Update is called once per frame
    void FixedUpdate(){
        if (player.transform.position.x > triggerPosition){
            scrolling = true;
        }
        if(scrolling)  
            transform.Translate(Vector3.right *scrollSpeed*Time.deltaTime);
    }
}
