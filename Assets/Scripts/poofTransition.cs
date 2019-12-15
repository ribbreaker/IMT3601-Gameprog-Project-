using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poofTransition : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        if (stateInfo.normalizedTime >= 1) {
            //animator.SetBool("Chasing", true);
        }
    }
}
