using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    /*Currently the script does not take into account the framerate, which could cause problems on old conputers*/


    //get the player
    private GameObject player;
    //the frames behind the target
    [SerializeField] float delay;
    [SerializeField] float activationTime;
    //Stores position and time 
    private Queue<TimePositionData> playerPos;
    float currentTime;
    bool chasing;
    private SpriteRenderer sr;


    void Start() {
        if (activationTime == 0)
            activationTime = 3;
        player = GameObject.Find("Player");
        if (delay == 0)
            delay = 3;
        playerPos = new Queue<TimePositionData>();
        sr = GetComponent<SpriteRenderer>();
        playerPos.Peek().time = 0;
    }

    void Update() {
        currentTime = Time.time;
        if (currentTime >= activationTime)
            chasing = true;
        //while there's a time difference, move to that position 
        //*****Queue.Peek() returns the first of the queue
        if (chasing && playerPos.Count != 0) {
            //Move to the position data
            if (playerPos.Peek().position.x > transform.position.x)
                sr.flipX = true;
            if (playerPos.Peek().position.x < transform.position.x)
                sr.flipX = false;
            if (transform.position != playerPos.Peek().position && playerPos.Peek().time >= (currentTime - delay)) {
                transform.position = new Vector3(playerPos.Peek().position.x, playerPos.Peek().position.y);
            }
            //Pop the position data
            playerPos.Dequeue();
        }
        if (player != null) {
            var timePositionData = new TimePositionData(currentTime, player.transform.position);
            //Add to the queue
            playerPos.Enqueue(timePositionData);
        }

    }
}
public class TimePositionData {
    //time is current time
    public float time;
    //vector 2 is the player's position
    public Vector3 position;
    public TimePositionData(float t, Vector3 pos) {
        time = t;
        position = pos;
    }
}
    
