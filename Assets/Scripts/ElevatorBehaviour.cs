using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    [SerializeField] float elevatorSpeed;
    bool rising;
    bool stopped;
    // Start is called before the first frame update
    void Start()
    {
     if(elevatorSpeed == 0){
            elevatorSpeed = 5;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //It's completely neutral right now
        if(!rising && !stopped){
            if(collision.gameObject == GameObject.FindGameObjectWithTag("Player")){
                rising = true;
                Debug.Log("Now eh's movin'!");
            }
        }
        //it's been stopped by a 'stopper' object
        if (collision.gameObject == GameObject.FindGameObjectWithTag("elevatorStopper")){
            Debug.Log("He's colidin' ya wee cunt");
            stopped = true;
            rising = false;
        }else
        {
            stopped = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (rising){
            //Gamers rise up
            if (!stopped){
                transform.position = new Vector3(transform.position.x, transform.position.y + elevatorSpeed);
            }
        }
    }
}
