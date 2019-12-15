using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaRising : MonoBehaviour
{

    private Camera cam;
    [SerializeField] private float speed;
    [SerializeField] GameObject player;
    private bool rising;
    private float playerY;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;    
    }

    // Update is called once per frame
    void Update()
    {
        playerY = player.transform.position.y;
        //if it's below the camera's boundary, move it up to the boundary, then just continue rising like normally
        if(transform.position.y < cam.transform.position.y - 9) {
            transform.position = new Vector3(transform.position.x, cam.transform.position.y - 9);
            rising = true;
        }  
        if(rising)
            transform.position = new Vector3(transform.position.x, transform.position.y + speed);
        //if it's covered the whole screen, stop rising
        //alternatively, if the player is dead, stop rising
        if (transform.position.y <= playerY) {
            rising = false;
        }
    }
}
