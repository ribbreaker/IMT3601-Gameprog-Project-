using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockIsland5 : MonoBehaviour
{
    bool active;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player){
            active = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (active){
            player.GetComponent<playerController>().goneThroughGoldDoor = true;
        }
    }
}
