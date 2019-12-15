using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDead : StateMachineBehaviour
{
    public GameObject drop;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
        if(drop != null)
            Instantiate(drop, animator.gameObject.transform.position, animator.gameObject.transform.rotation);
    }
}
