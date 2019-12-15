using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    Camera cam;
    float height;
    //What the camera is currently following
    public GameObject target;
    //Dampening effect
    public float smoothing;
    public float lowBorder, highBorder, farLeft, farRight;

    Vector3 offset;
    float lowY;
    float highY;

    void Start(){
        target = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
        height = cam.orthographicSize;
        //stay a certain length away from the target
        if(target != null)
        {
            offset = transform.position - target.transform.position;
        }
        //Low Y is the initial y of the camera
        lowY = lowBorder + height;
        highY = highBorder - height;
    }
    void FixedUpdate(){
        target = GameObject.FindGameObjectWithTag("Player");
        //Where camera WANTS to be located
        if (target != null){
            Vector3 targetCamPos = target.transform.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);
            //Makes sure the camera Y can't go out of bounds
            if(transform.position.y < lowY)
                transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
            if(transform.position.y > highY)
                transform.position = new Vector3(transform.position.x, highY, transform.position.z);

            //Make sure the camera can't go out of bounds on left/right
            if (transform.position.x < farLeft)
                transform.position = new Vector3(farLeft, transform.position.y, transform.position.z);
            if (transform.position.x > farRight)
                transform.position = new Vector3(farRight, transform.position.y, transform.position.z); 
        }
    }
}
