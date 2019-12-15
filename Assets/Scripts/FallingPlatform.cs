using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Vector3 startPos;
    [SerializeField] float fallSpeed;
    [SerializeField] float maxWaitTime;
    [SerializeField] float maxFallTime;
    [SerializeField] float respawnTime;
    float waitTime;
    bool falling;
    bool waiting;
    bool respawning;

    void OnCollisionEnter2D(Collision2D other) {
        startPos = transform.localPosition;
        if (other.gameObject.tag == "Player") {
            waiting = true;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            waiting = false;
            waitTime = 0;
        }
    }
    // Start is called before the first frame update
    void Start(){

     if (fallSpeed == 0) {
            fallSpeed = 10;
        }   
     if (maxFallTime == 0) {
            maxFallTime = 3;
        }
     if(maxWaitTime == 0) {
            maxWaitTime = 1;
        }
     if(respawnTime == 0) {
            respawnTime = 3;
        }
    }

    // Update is called once per frame
    void Update(){
        //start shit once it's in contact with the player
        if (waiting) {
            waitTime += Time.deltaTime;
            if(waitTime >= maxWaitTime) {
                falling = true;
                waiting = false;
                waitTime = 0;
            }
        }
        //fall down 
        if (falling) {
            waitTime += Time.deltaTime;
            fallDown();
            //Make it disappear once it's fallen far enough down
            if (waitTime >= maxFallTime) {
                falling = false;
                Debug.Log("Platform is destroyed!");
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Renderer>().enabled = false;
                respawning = true;
                waitTime = 0;
            }
        }
        //alright now come back already
        if (respawning) {
            waitTime += Time.deltaTime;
            //Come back ye scallywag
            if (waitTime >= respawnTime) {
                transform.localPosition = startPos;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.GetComponent<Renderer>().enabled = true;
                respawning = false;
                waitTime = 0;
            }
        }

    }
    void fallDown() {
        transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed * Time.deltaTime);
    }
}
