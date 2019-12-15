using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCollect : AbstractCollectable
{  
    public GameObject player;
    private playerStats stats;

    void Awake() {
        stats = FindObjectOfType<playerStats>();
    }
    private void OnTriggerStay2D(Collider2D collider){
        if (collider.tag == "Player"){
            Collected(stats);
        }
    }
    public override void Collected(playerStats Stats){
        Stats.IncreaseOrbs();
        gameObject.SetActive(false);
    }
}
