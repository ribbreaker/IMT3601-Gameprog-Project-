using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSceneWarp : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player) {
            //JUMP TO SELF
            player.transform.position = transform.position;
        }
    }
}
