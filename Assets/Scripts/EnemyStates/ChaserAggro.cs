using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserAggro : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 startPos;
    [SerializeField] float moveSpeed;
    GameObject player;
    Rigidbody2D rb;


    bool chasing;

    void Start() {
        startPos = gameObject.transform.parent.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player")) {
            player = other.gameObject;
            chasing = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player")){
            chasing = false;
        }
    }
    void Update() {
        if (player != null) {
            playerPos = player.transform.position;
        }
        //Move towards the player
        if (chasing) {
            gameObject.transform.parent.GetComponentInParent<ChaserMovetowards>().MoveToHere(playerPos, moveSpeed);
        }
        //go back to where you started
        else
        {
            gameObject.transform.parent.GetComponentInParent<ChaserMovetowards>().MoveToHere(startPos, moveSpeed);
        }
    }
}
