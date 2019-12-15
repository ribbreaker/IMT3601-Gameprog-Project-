using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyProjectile : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);   
    }
}
