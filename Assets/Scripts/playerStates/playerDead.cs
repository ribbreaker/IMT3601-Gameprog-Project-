using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDead : StateMachineBehaviour
{
    bool menuLoaded = false;
    bool fadingOut;
    //for readability
    GameObject player;
    GameObject transition;
    private playerStats stats;
    bool loading;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        player.GetComponent<BoxCollider2D>().enabled = false;   
	    player.GetComponent<playerStats>().DecreaseLives();
        player.GetComponent<playerController>().fadingOut = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        player = animator.gameObject;
        transition = player.GetComponent<playerController>().transition;
        //let the death animation play once and then gtfo
        if (stateInfo.normalizedTime >= 1) {
            //disappear for the time being
            player.GetComponent<SpriteRenderer>().enabled = false;
            //you're dead, fool
            player.GetComponent<playerController>().imDead = true;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Debug.Log("Player is out of deadstate");
        GameObject player = animator.gameObject;
        player.GetComponent<playerController>().imDead = false;
    }
}
