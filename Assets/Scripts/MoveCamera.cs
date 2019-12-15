using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    [SerializeField] Camera cam;
    followCamera followCam;
    [SerializeField] float smoothing;
    bool moveCam = false;

    // Start is called before the first frame update
    void Start() {
        cam = Camera.main;
        followCam = cam.GetComponent<followCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {
            followCam.enabled = false;
            moveCam = true;
        }
    }

    //It makes the camera zoom in when the player dies, it's weird and janky.
    /*private void OnTriggerExit2D(Collider2D collision) {
        if (collision.name == "Player") {
            followCam.enabled = true;
            moveCam = false;
        }
    }*/

    private void Update() {
        if (moveCam) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position, smoothing * Time.deltaTime);
        }
    }
}